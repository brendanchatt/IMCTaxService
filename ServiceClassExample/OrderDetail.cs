using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassExample
{
    public class OrderDetail
    {
        public float Amount { get; set; }
        public float Shipping { get; set; }
        public string CustomerId { get; set; }
        public string ExemptionType { get; set; }
        public Address[] Nexuses { get; set; }
        public  LineItem[] LineItems { get; set; }
    }
}
