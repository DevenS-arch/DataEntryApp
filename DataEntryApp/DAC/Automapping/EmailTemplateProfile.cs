using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.DAC.POCOEntities;
using DataEntryApp.Entities;

namespace DataEntryApp.DAC.Automapping
{
    public class EmailTemplateProfile : Profile
    {

        public EmailTemplateProfile()
        {
            CreateMap<EmailTemplate, EmailTemplateDTO>();
            CreateMap<EmailTemplateDTO, EmailTemplate>();
            CreateMap<EmailTemplateField, EmailTemplateFieldDTO>();
            CreateMap<EmailTemplateFieldDTO, EmailTemplateField>();
        }
    }
}
