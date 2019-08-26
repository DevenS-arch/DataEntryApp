using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.Entities;
using DataEntryApp.DAC.POCOEntities;

namespace DataEntryApp.DAC.Automapping
{
    public class DivisionProfile : Profile
    {

        public DivisionProfile()
        {
            CreateMap<Division, DivisionDTO>();
        }
    }
}
