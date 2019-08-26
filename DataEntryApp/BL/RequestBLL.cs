using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.DAC;
using DataEntryApp.Entities;
using static AutoMapper.Mapper;

namespace DataEntryApp.BL
{
    public class RequestBLL
    {
        public List<RequestDTO> GetRequests(string divisionId)
        {
            var requests = RequestDAL.GetRequests(divisionId);

            if (requests == null) return null;

            return Map<List<RequestDTO>>(requests);
        }
    }
}
