using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTicket.DataEntry.Entities;
using TechTicket.DataEntry.DAC.POCOEntities;

namespace TechTicket.DataEntry.DAC.Automapping
{
    public class DivisionProfile : Profile
    {

        public DivisionProfile()
        {
            CreateMap<Division, DivisionDTO>();
        }
    }
}
