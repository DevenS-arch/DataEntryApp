using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTicket.DataEntry.DAC.POCOEntities
{
    public class EmailTransctionLog
    {
        public string Id { get; set; }
        public string EmailTemplateId { get; set; }
        public string From { get; set; }
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public string EmailBody { get; set; }
        public DateTime SentOn { get; set; }
        public string SentBy { get; set; }
    }
}
