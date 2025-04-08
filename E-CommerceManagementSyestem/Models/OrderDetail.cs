using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceManagementSyestem.Models
{
    internal class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public double Price { get; set; }

        public string SKU { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public int OrderId { get; set; } 
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product{ get; set; }

        public override string ToString()
        {
            return $"Product:{Product?.ProductName ?? "Unknown"},SKU:{SKU},Quantity:{Quantity},Price:{Price}";
        }


    }
}
