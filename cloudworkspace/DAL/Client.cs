//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public Client()
        {
            this.Addresses = new HashSet<Address>();
            this.Phones = new HashSet<Phone>();
            this.Projects = new HashSet<Project>();
        }
    
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsACompany { get; set; }
        public bool IsArchived { get; set; }
        public int GroupId { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
