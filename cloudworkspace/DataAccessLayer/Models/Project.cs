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
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal? EstimatedAmount { get; set; }// SQL money

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm}")]
        public DateTime? EstimatedTime { get; set; }   
     
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CompletionDate { get; set; }

        public List<Platform> Platform { get; set; }

        public string Lanuage { get; set; }

        [DefaultValue(false)]
        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }
    }
}
