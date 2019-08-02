using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Entities
{
    public class Ref
    {
        public Guid RefID { get; set; }
        public DateTime RefDate { get; set; }
        public string RefNo { get; set; }
        public string RefType { get; set; }
        public decimal Total { get; set; }
        public string ContactName { get; set; }
        public string Reason { get; set; }

    }
}