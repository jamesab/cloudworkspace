using CloudWorkSpace.DAL;
using CloudWorkSpace.DAL.DTO;
using CloudWorkSpace.DAL.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudWorkSpace.DAL.ViewModels
{
    public class ProjectViewModel
    {
        #region Client

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
        [DisplayName("Address Name")]
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

        #endregion

        #region Project

        [Key]
        public int ProjectId { get; set; }
        [Required]
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Estimated Amount")]
        public decimal? EstimatedAmount { get; set; }// SQL money

        [DisplayName("Current Status")]
        public CurrentStatus CurrentStatus { get; set; }

        [DataType(DataType.Time)]
        [DisplayName("Estimated Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? EstimatedTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Due Date")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Completion Date")]
        public DateTime? CompletionDate { get; set; }
        
        public int ClientId { get; set; }
        
        [ForeignKey("ClientId")]
        public CloudWorkSpace.DAL.DTO.Client Client { get; set; }

        public virtual ICollection<CloudWorkSpace.DAL.DTO.Platform> Platform { get; set; }
        public virtual ICollection<Note> Notes { get; set; }

        public string Language { get; set; }

        [DefaultValue(false)]
        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }

        #endregion
    }
}
