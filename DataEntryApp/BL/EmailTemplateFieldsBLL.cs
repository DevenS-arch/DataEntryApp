
using DataEntryApp.DAC;
using DataEntryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AutoMapper.Mapper;

namespace DataEntryApp.BL
{
    public class EmailTemplateFieldsBLL
    {
        public List<EmailTemplateFieldDTO> GetEmailTemplateFields(string emialTemplateId)
        {
            // return EmailTemplateFeildsDAL.GetEmailTemplateFeilds(emialTemplateId);
            return Map<List<EmailTemplateFieldDTO>>(EmailTemplateFieldsDAL.GetEmailTemplateFields(emialTemplateId));
        }
    }
}