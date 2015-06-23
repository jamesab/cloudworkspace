using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudWorkSpace.DAL.ViewModels
{
    public class ClientViewModel
    {

        [Key]
        public int ClientId { get; set; }

        public int AddressId { get; set; }
        public int PhoneId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone Type")]
        [DefaultValue("Primary")]
        public string PhoneName { get; set; }
        [Required]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DefaultValue("Home")]
        public string AddressName { get; set; }
        [Required]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string ZipCode { get; set; }

        [DefaultValue(false)]
        [DisplayName("Company")]
        public bool IsACompany { get; set; }
    }
}
