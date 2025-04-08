using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceManagementSyestem.Models
{
    internal class Product
    {
        public int ProductId { get; set; }
        [MaxLength(50)]
        [Required]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public double Price { get; set; }
        public double  Weight { get; set; }
        public string ProductSKU { get; set; } = string.Empty;
                     
        public string Thumbnail { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int  Stock { get; set; } // with default val = 1 
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ProductOption> ProductOptions { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }

    }
}
