using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceManagementSyestem.Models
{
    internal class Option
    {
        public int OptionId {  get; set; }
       
        public string OptionName { get; set; } = string.Empty;
    }
}
