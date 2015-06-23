using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DefaultValue(false)]
        [ScaffoldColumn(false)]
        public bool IsACompany { get; set; }
        [DefaultValue(false)]
        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }

        public int AddressId { get; set; }
        public int PhoneId { get; set; }

        public List<Phone> Phone { get; set; }
        public List<Address> Address { get; set; }
        
        //private ICollection<Phone> _phone;
        //private ICollection<Address> _address;

        //public Client()
        //{
        //    _phone = new List<Phone>();
        //    _address = new List<Address>();
        //}
    }
}
