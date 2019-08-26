using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.Entities;

namespace DataEntryApp.DAC.POCOEntities
{
    public class Request : IAuditable
    {
        public string Id { get; set; }
        public string RequestName { get; set; }
        public string DivisionId { get; set; }
        public string ParentRequestId { get; set; }
        public List<string> ChildRequestIds { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
