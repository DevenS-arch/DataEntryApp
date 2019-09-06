using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.DAC;
using DataEntryApp.Entities;
using static AutoMapper.Mapper;

namespace DataEntryApp.BL
{
    public class EmailTemplateBLL
    {
        public EmailTemplateDTO GetEmailTemplate(string requestId)
        {
            return EmailTemplateDAL.GetEmailTemplate(requestId);
        }

        public void SaveEmailTemplate(EmailTemplateDTO emailTemplateDTO)
        {
            EmailTemplateDAL.SaveEmailTemplate(emailTemplateDTO);
        }

        public void DeleteEmailTemplate(string templateId)
        {
            EmailTemplateDAL.DeleteEmailTemplate(templateId);
        }
    }
}
