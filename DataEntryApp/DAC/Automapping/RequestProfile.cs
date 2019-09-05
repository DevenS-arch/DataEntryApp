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
    public class RequestProfile : Profile
    {

        public RequestProfile()
        {
            CreateMap<Request, RequestDTO>()
                .ForMember(x => x.ChildRequests, opt => opt.Ignore())
                .ForMember(x => x.ParentRequest, opt => opt.Ignore());
                 
        }
    }
}
