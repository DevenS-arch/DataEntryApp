using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTicket.DataEntry.Entities
{
    public class RequestDTO : IAuditable
    {
        public string Id { get; set; }
        public string RequestName { get; set; }
        public string DivisionId { get; set; }
        public string ParentRequestId { get; set; }
        public DivisionDTO Division { get; set; }
        public RequestDTO ParentRequest { get; set; }
        public List<RequestDTO> ChildRequests { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
