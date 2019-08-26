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
