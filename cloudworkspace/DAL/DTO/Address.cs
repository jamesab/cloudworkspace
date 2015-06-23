using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudWorkSpace.DAL.DTO
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string ZipCode { get; set; }
                
        public int ClientId { get; set; }                
        public virtual Client Client { get; set; }
    }
}
