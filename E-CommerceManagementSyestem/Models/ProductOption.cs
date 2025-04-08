using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceManagementSyestem.Models
{
    internal class ProductOption
    {
        public int ProductOptionId {  get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OptionId { get; set; }
        public Option Option { get; set; }
    }
}
