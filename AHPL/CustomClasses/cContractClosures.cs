using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMS
{
    public  class cContractClosures
    {
        public int ContractClosureDetailID { get; set; }
        public int ContractClosureID { get; set; }
        public int ContractClosureItemID { get; set; }
        public int ClosureMappingItemID { get; set; }
        public string Contents { get; set; }
        public decimal ContentValue { get; set; }
        public bool IsValueType { get; set; }
        public bool Select { get; set; }

    }
}
