using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using BCrypt.Net;
using System.ComponentModel.DataAnnotations;
namespace E_CommerceManagementSyestem.Models
{
    internal class Customer
    {
       public int CustomerId { get; set; }
        [MaxLength(50)]
        public string Email {  get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? BillingAdderss { get; set; }
        [MaxLength(100)]
        public string Default_Shipping_Address {  get; set; } 
        [MaxLength(11)]
        public string phone { get; set; } = string.Empty;
        [MaxLength(10)]  
        public string Country { get; set; }
        [Required]
        public string HashedPassword { get; private set; }

        public List<Order>Orders { get; set; }

        public void SetPassword(string password)
        {
            HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, HashedPassword);
        }
    }
}
