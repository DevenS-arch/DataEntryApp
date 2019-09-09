using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTicket.DataEntry.DAC;
using TechTicket.DataEntry.Entities;
using static AutoMapper.Mapper;

namespace TechTicket.DataEntry.BL
{
    public class EmailTemplateBLL
    {
        public EmailTemplateDTO GetEmailTemplate(string requestId)
        {
            return EmailTemplateDAL.GetEmailTemplate(requestId);
        }

        public void SaveEmailTemplate(EmailTemplateDTO emailTemplateDTO)
        {

            if (emailTemplateDTO.Fields != null && emailTemplateDTO.Fields.Count > 0)
            {

                emailTemplateDTO.Fields.ForEach(f =>
                {

                    if (f.FieldType.Equals("TextBox", StringComparison.CurrentCultureIgnoreCase))
                    {
                        f.FormatRegEx = @"/[\w\s]/";
                    }

                });

            }

            EmailTemplateDAL.SaveEmailTemplate(emailTemplateDTO);
        }

        public void DeleteEmailTemplate(string templateId)
        {
            EmailTemplateDAL.DeleteEmailTemplate(templateId);
        }
    }
}
