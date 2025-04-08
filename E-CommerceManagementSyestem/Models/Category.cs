using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceManagementSyestem.Models
{
    internal class Category
    {
     
        public int CategoryId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string thumbnall { get; set; }

        public List<ProductCategory> roductCategories { get; set; }
    }
}
