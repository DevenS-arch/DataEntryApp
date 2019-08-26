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
    public class RequestProfile : Profile
    {

        public RequestProfile()
        {
            CreateMap<Request, RequestDTO>();
        }
    }
}
