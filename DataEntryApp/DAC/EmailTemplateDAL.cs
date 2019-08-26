using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoMapper.Mapper;
using DataEntryApp.Common.Models;
using DataEntryApp.Common.DAC.POCOEntities;

namespace DataEntryApp.Common.DAC
{
    public static class EmailTemplateDAL
    {
        public static EmailTemplateDTO GetEmailTemplate(int requestId)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    var emailTemplate = dbSession.Query<EmailTemplate>()
                                    .FirstOrDefault(et => et.RequestId == requestId);


                    if (emailTemplate == null)
                        return null;

                    //var templateFields = dbSession.Include<EmailTemplateField>(et => et.FieldOptionsIds)
                    //                              .Load<EmailTemplateField>(emailTemplate.TemplateFieldIds.Cast<ValueType>())
                    //                              .OrderBy(tf => tf.FieldOrder)
                    //                              .ToList();

                    var emailTemplateDTO = Map<EmailTemplateDTO>(emailTemplate);

                    //if (templateFields.Count > 0)
                    //{
                    //    emailTemplateDTO.Fields = new List<EmailTemplateFieldDTO>();

                    //    templateFields.ForEach((tf) => 
                    //    {
                    //        var fieldDTO = Map<EmailTemplateFieldDTO>(tf);

                    //        if (tf.FieldOptionsIds != null && tf.FieldOptionsIds.Count > 0)
                    //        {
                    //            var fieldOptions = dbSession.Load<FieldOption>(tf.FieldOptionsIds.Cast<ValueType>())
                    //                                             .ToList();

                    //            fieldDTO.FieldOptions = Map<List<FieldOptionDTO>>(fieldOptions);
                    //        }

                    //        emailTemplateDTO.Fields.Add(fieldDTO);
                    //    });

                    //}

                    return emailTemplateDTO;
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
