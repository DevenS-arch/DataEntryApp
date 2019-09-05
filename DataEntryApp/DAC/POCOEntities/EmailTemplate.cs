﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryApp.Entities;

namespace DataEntryApp.DAC.POCOEntities
{
    public class EmailTemplate : IAuditable
    {
        public string Id { get; set; }
        public string RequestId { get; set; }
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public string TemplateName { get; set; }
        public string Description { get; set; }
        public string EmailTemplateBody { get; set; }
        public List<string> TemplateFieldIds { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}