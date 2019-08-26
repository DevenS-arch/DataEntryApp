using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.Common.Models;
using DataEntryApp.Common.DAC.POCOEntities;

namespace DataEntryApp.Common.DAC.Automapping
{
    public class DivisionProfile : Profile
    {

        public DivisionProfile()
        {
            CreateMap<Division, DivisionDTO>();
        }
    }
}
