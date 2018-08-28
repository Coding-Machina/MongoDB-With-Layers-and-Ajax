using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.EF
{
    public class Transaction
    {
        public string TransactionDate { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string Operation { get; set; }
    }
}
