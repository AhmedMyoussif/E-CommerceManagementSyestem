using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceManagementSyestem.Models
{
    internal class Order
    {
        public int OrderId { get; set; }
        public int Ammount { get; set; }
    
        public string ShippingAddress { get; set; }

        public string OrderAddress {  get; set; }
        public string OrderEmail { get; set; } = string.Empty;
        
        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; } = string.Empty ;

        public int CustomerId { get; set; } 
        public Customer Customer { get; set; }
        public List<OrderDetail>OrderDetails { get; set; }
    }
}
