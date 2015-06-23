using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CloudWorkSpace.DAL.DTO
{
    public class Client
    {
        public Client()
        {
            Phone = new List<Phone>();
            Address = new List<Address>();
        }

        [Key]
        public int ClientId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]        
        public string Email { get; set; }

        [DefaultValue(false)]
        public bool IsACompany { get; set; }

        [DefaultValue(false)]
        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }

        public virtual ICollection<Phone> Phone { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
