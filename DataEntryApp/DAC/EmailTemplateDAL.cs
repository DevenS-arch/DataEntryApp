using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoMapper.Mapper;
using TechTicket.DataEntry.Entities;
using TechTicket.DataEntry.DAC.POCOEntities;

namespace TechTicket.DataEntry.DAC
{
    public static class EmailTemplateDAL
    {
        public static EmailTemplateDTO GetEmailTemplate(string requestId)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    var emailTemplate = dbSession
                        .Query<EmailTemplate>()
                        .FirstOrDefault(et => et.RequestId == requestId);


                    if (emailTemplate == null || emailTemplate.TemplateFieldIds == null)
                        return null;

                    var templateFields = dbSession.Include<EmailTemplateField>(et => et.FieldOptionsIds)
                                                 .Load<EmailTemplateField>(emailTemplate.TemplateFieldIds.ToArray<string>())
                    .OrderBy(tf => tf.Value.FieldOrder).Select(s => s.Value)
                    .ToList();

                    var emailTemplateDTO = Map<EmailTemplateDTO>(emailTemplate);

                    if (templateFields.Count > 0)
                    {
                        emailTemplateDTO.Fields = new List<EmailTemplateFieldDTO>();

                        templateFields.ForEach((tf) =>
                        {
                            var fieldDTO = Map<EmailTemplateFieldDTO>(tf);

                            if (tf.FieldOptionsIds != null && tf.FieldOptionsIds.Count > 0)
                            {
                                var fieldOptions = dbSession.Load<FieldOption>(tf.FieldOptionsIds).Select(s => s.Value)
                                                                 .ToList();

                                fieldDTO.FieldOptions = Map<List<FieldOptionDTO>>(fieldOptions);
                            }

                            emailTemplateDTO.Fields.Add(fieldDTO);
                        });

                    }

                    return emailTemplateDTO;
                }
                catch
                {
                    dbSession.Advanced.Clear();
                    throw;
                }

            }
        }

        public static void UpdateEmailTemplate(EmailTemplateDTO emailTemplateDTO)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {
                //fetch the template for the given request id
                var emailTemplate = dbSession
                       .Query<EmailTemplate>()
                       .FirstOrDefault(et => et.RequestId == emailTemplateDTO.RequestId);

                //if email template doesnot exists, return
                if (emailTemplate == null)
                {
                    return;
                }

                //if emailtemplateDTO has field then procees
                if (emailTemplateDTO.Fields != null && emailTemplateDTO.Fields.Count > 0)
                {
                    var fieldList = Map<List<EmailTemplateField>>(emailTemplateDTO.Fields);

                    //add ids of existing options to the field
                    for (int k = 0; k < fieldList.Count; k++)
                    {
                        if (emailTemplateDTO.Fields[k].FieldOptions != null)
                        {
                            fieldList[k].FieldOptionsIds = emailTemplateDTO.Fields[k].FieldOptions.Select(fo => fo.Id).Where(x => x != null).ToList();
                        }
                    }

                    //get existing fields
                    var fieldListSaved = dbSession
                                        .Query<EmailTemplateField>()
                                         .Where(f => f.EmailTemplateId == emailTemplate.Id).ToList();

                    fieldListSaved.RemoveAll(a => !fieldList.Exists(b => a.Id == b.Id));

                    for (int j = 0; j < fieldList.Count; j++)

                    {
                        //if field is not existing/new
                        if (fieldList[j].Id == null)
                        {
                            //store the new field
                            dbSession.Store(fieldList[j]);
                            emailTemplateDTO.Fields[j].Id = fieldList[j].Id;

                            //store the options(new) of new field, add id of new option to field and assign field id to options
                            FieldOption option;
                            emailTemplateDTO.Fields.Where(x => x.Id == fieldList[j].Id).FirstOrDefault().FieldOptions.ForEach(
                                o =>
                                {
                                    option = Map<FieldOption>(o);
                                    if (o.Id == null)
                                    {
                                        option.TemplateFieldId = fieldList[j].Id;
                                        dbSession.Store(option);
                                        fieldList[j].FieldOptionsIds.Add(option.Id);
                                    }
                                });
                        }
                        else
                        {
                            //if field is existing
                            for (int i = 0; i < fieldListSaved.Count; i++)
                            {
                                //select the retaining fields in fieldListSaved to update its properties
                                if (fieldList[j].Id == fieldListSaved[i].Id)
                                {
                                    //get the field options for existing field and delete non-retained options of it
                                    var fieldOptions = dbSession
                                                .Load<FieldOption>(fieldListSaved[j].FieldOptionsIds.ToArray<string>())
                                                .Select(s => s.Value)
                                                .ToList();

                                    fieldOptions.RemoveAll(a => fieldList[i].FieldOptionsIds.Exists(b => a.Id == b));
                                    fieldOptions.ForEach(o =>
                                    {
                                        dbSession.Delete(o);
                                    });

                                    //update properties of field in fieldListSaved
                                    Mapper.Map<EmailTemplateField, EmailTemplateField>(fieldList[j], fieldListSaved[i]);

                                    // save new options, add id of new option to field and assign field id to options 
                                    FieldOption option;
                                    emailTemplateDTO.Fields.Where(x => x.Id == fieldListSaved[i].Id).FirstOrDefault().FieldOptions.ForEach(
                                        o =>
                                        {
                                            option = Map<FieldOption>(o);
                                            if (o.Id == null)
                                            {
                                                option.TemplateFieldId = fieldListSaved[i].Id;
                                                dbSession.Store(option);
                                                fieldListSaved[i].FieldOptionsIds.Add(option.Id);
                                            }

                                        });
                                }
                                else
                                {

                                }
                            }

                        }

                    }

                    //delete non-retained fields
                    var templateFields = dbSession.Include<EmailTemplateField>(et => et.FieldOptionsIds)
                                                 .Load<EmailTemplateField>(emailTemplate.TemplateFieldIds.ToArray<string>())
                                                 .OrderBy(tf => tf.Value.FieldOrder).Select(s => s.Value)
                                                 .ToList();
                    templateFields.RemoveAll(a => fieldList.Exists(b => a.Id == b.Id));
                    if (templateFields.Count > 0)
                    {
                        templateFields.ForEach((tf) =>
                        {
                            if (tf.FieldOptionsIds != null && tf.FieldOptionsIds.Count > 0)
                            {
                                var fieldOptions = dbSession.Load<FieldOption>(tf.FieldOptionsIds).Select(s => s.Value)
                                                                  .ToList();
                                fieldOptions.ForEach(fo => dbSession.Delete(fo));
                            }
                            dbSession.Delete(tf);
                        });

                    }

                    //add field ids to template
                    emailTemplate.TemplateFieldIds = fieldList.Select(f => f.Id).ToList();

                    dbSession.SaveChanges();

                }
            }
        }
        public static void SaveEmailTemplate(EmailTemplateDTO emailTemplateDTO)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {
                var emailTemplate = Map<EmailTemplate>(emailTemplateDTO);
                dbSession.Store(emailTemplate);

                if (emailTemplateDTO.Fields != null && emailTemplateDTO.Fields.Count > 0)
                {
                    var fieldList = Map<List<EmailTemplateField>>(emailTemplateDTO.Fields);
                    for (int i = 0; i < fieldList.Count; i++)
                    {
                        fieldList[i].EmailTemplateId = emailTemplate.Id;
                        dbSession.Store(fieldList[i]);
                        emailTemplateDTO.Fields[i].Id = fieldList[i].Id;
                    }

                    fieldList.ForEach(fld =>
                    {
                        fld.EmailTemplateId = emailTemplate.Id;
                        dbSession.Store(fld);
                    });

                    emailTemplate.TemplateFieldIds = fieldList.Select(f => f.Id).ToList();

                    for (int i = 0; i < emailTemplateDTO.Fields.Count; i++)
                    {
                        var optionList = Map<List<FieldOption>>(emailTemplateDTO.Fields[i].FieldOptions);
                        if (optionList != null && optionList.Count > 0)
                        {
                            optionList.ForEach(fo =>
                            {
                                fo.TemplateFieldId = emailTemplateDTO.Fields[i].Id;
                                dbSession.Store(fo);
                            });

                            fieldList[i].FieldOptionsIds = optionList.Select(f => f.Id).ToList();
                        }
                    }

                    dbSession.SaveChanges();
                }

            }
        }

        public static void DeleteEmailTemplate(string templateId)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {
                var emailTemplate = dbSession.Query<EmailTemplate>()
                                   .FirstOrDefault(et => et.Id == templateId);

                if (emailTemplate.TemplateFieldIds != null)
                {
                    var templateFields = dbSession.Include<EmailTemplateField>(et => et.FieldOptionsIds)
                                                     .Load<EmailTemplateField>(emailTemplate.TemplateFieldIds.ToArray<string>())
                        .OrderBy(tf => tf.Value.FieldOrder).Select(s => s.Value)
                        .ToList();

                    if (templateFields.Count > 0)
                    {
                        templateFields.ForEach((tf) =>
                        {
                            if (tf.FieldOptionsIds != null && tf.FieldOptionsIds.Count > 0)
                            {
                                var fieldOptions = dbSession.Load<FieldOption>(tf.FieldOptionsIds).Select(s => s.Value)
                                                                  .ToList();
                                fieldOptions.ForEach(fo => dbSession.Delete(fo));
                            }
                            dbSession.Delete(tf);
                        });

                    }
                }

                dbSession.Delete(emailTemplate);
                dbSession.SaveChanges();
            }
        }

        public static List<FieldInfo> GetFieldsInfo(string temaplateId)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    List<FieldInfo> fieldInfo = new List<FieldInfo>();
                    var templateFieldIds = dbSession
                        .Load<EmailTemplate>(temaplateId).TemplateFieldIds;

                    if (templateFieldIds != null)
                    {
                        var templateFields = dbSession.Load<EmailTemplateField>(templateFieldIds.ToArray<string>())
                        .OrderBy(tf => tf.Value.FieldOrder).Select(s => s.Value)
                        .ToList();

                        templateFields.ForEach(f =>
                        {
                            var fInfo = new FieldInfo() { FieldName = f.FieldName, FieldType = f.FieldType };
                            fieldInfo.Add(fInfo);

                        });
                    }

                     return fieldInfo;
                }
                catch
                {
                    dbSession.Advanced.Clear();
                    throw;
                }

            }
        }

    }
}
