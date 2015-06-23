using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Phone
    {
        public int PhoneId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public Client ClientId { get; set; }
    }
}
