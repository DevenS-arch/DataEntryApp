using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.Common.Models;

namespace DataEntryApp.Common.DAC.POCOEntities
{
    public class Request : IAuditable
    {
        public string Id { get; set; }
        public string RequestName { get; set; }
        public string DivisionId { get; set; }
        public int? ParentRequestId { get; set; }
        public List<int> ChildRequestIds { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
