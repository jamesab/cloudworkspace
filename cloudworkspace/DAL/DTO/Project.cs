using CloudWorkSpace.DAL.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudWorkSpace.DAL.DTO
{
    public class Project
    {
        public Project()
        {
            //Client = new Client();
            Clients = new List<Client>();
            Platform = new List<Platform>();
            Notes = new List<Note>();
        }

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
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Completion Date")]
        public DateTime? CompletionDate { get; set; }

        public virtual ICollection<Platform> Platform { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

        public string Language { get; set; }

        [DefaultValue(false)]
        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }
    }
}
