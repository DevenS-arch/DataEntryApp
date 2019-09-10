using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTicket.DataEntry.DAC;
using TechTicket.DataEntry.DAC.POCOEntities;
using TechTicket.DataEntry.Entities;
using static AutoMapper.Mapper;

namespace TechTicket.DataEntry.BL
{
    public class RequestBLL
    {
        public List<RequestDTO> GetRequests()
        {
            var requests = RequestDAL.GetRequests();

            if (requests == null) return null;

            return Map<List<RequestDTO>>(requests);
        }

        public RequestDTO GetRequest(RequestDTO request)
        {
            var requests = RequestDAL.GetRequest(Map<Request>(request));

            if (requests == null) return null;

            return Map<RequestDTO>(requests);
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
