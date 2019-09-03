using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoMapper.Mapper;
using DataEntryApp.Entities;
using DataEntryApp.DAC.POCOEntities;

namespace DataEntryApp.DAC
{
    public static class EmailTemplateDAL
    {
        public static EmailTemplateDTO GetEmailTemplate(string requestId)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    var emailTemplate = dbSession.Query<EmailTemplate>()
                                    .FirstOrDefault(et => et.RequestId == requestId);


                    if (emailTemplate == null)
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
                }
                dbSession.SaveChanges();
            }
        }
    }
}
