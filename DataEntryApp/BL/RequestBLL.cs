using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.DAC;
using DataEntryApp.DAC.POCOEntities;
using DataEntryApp.Entities;
using static AutoMapper.Mapper;

namespace DataEntryApp.BL
{
    public class RequestBLL
    {
        public List<RequestDTO> GetRequests()
        {
            var requests = RequestDAL.GetRequests();

            if (requests == null) return null;

            return Map<List<RequestDTO>>(requests);
        }
        public List<RequestDTO> GetRequestsForDivision(string divisionId)
        {
            var requests = RequestDAL.GetRequestsForDivision(divisionId);

            if (requests == null) return null;

            return Map<List<RequestDTO>>(requests);
        }

        public void AddRequests(List<RequestDTO> requests)
        {
            RequestDAL.AddRequests(Map<List<Request>>(requests));
        }

        public void UpdateRequests(RequestDTO requests)
        {
            RequestDAL.UpdateRequests(Map<Request>(requests));
        }

        public void DeleteRequests(RequestDTO request)
        {
            RequestDAL.DeleteRequests(Map<Request>(request));
        }
    }
}
