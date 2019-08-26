using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.Common.DAC.POCOEntities;
using DataEntryApp.Common.Models;

namespace DataEntryApp.Common.DAC.Automapping
{
    public class EmailTemplateProfile : Profile
    {

        public EmailTemplateProfile()
        {
            CreateMap<EmailTemplate, EmailTemplateDTO>();
            CreateMap<EmailTemplateField, EmailTemplateFieldDTO>();
        }
    }
}
