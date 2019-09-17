using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTicket.DataEntry.DAC.POCOEntities;
using TechTicket.DataEntry.Entities;

namespace TechTicket.DataEntry.DAC.Automapping
{
    public class EmailTemplateProfile : Profile
    {

        public EmailTemplateProfile()
        {
            CreateMap<EmailTemplate, EmailTemplateDTO>();
            CreateMap<EmailTemplateDTO, EmailTemplate>();
            CreateMap<EmailTemplateField, EmailTemplateFieldDTO>();
            CreateMap<EmailTemplateFieldDTO, EmailTemplateField>();
            CreateMap<EmailTemplateField, EmailTemplateField>();
        }
    }
}
