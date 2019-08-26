using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryApp.Common.Models

{
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
