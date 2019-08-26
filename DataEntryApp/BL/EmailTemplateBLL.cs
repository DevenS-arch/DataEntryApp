using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.Common.DAC;
using DataEntryApp.Common.Models;
using static AutoMapper.Mapper;

namespace DataEntryApp.Common.BL
{
    public class EmailTemplateBLL
    {
        public EmailTemplateDTO GetEmailTemplate(int requestId)
        {
            return EmailTemplateDAL.GetEmailTemplate(requestId);
        }
    }
}
