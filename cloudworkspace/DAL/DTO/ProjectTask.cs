using CloudWorkSpace.DAL.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CloudWorkSpace.DAL.DTO
{
    public class ProjectTask
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        [DisplayName("Project")]
        public string ProjectName { get; set; }
        [Required]
        [DisplayName("Task")]
        public string TaskName { get; set; }

        [DefaultValue(false)]
        [DisplayName("Bug")]
        public bool IsBug { get; set; }

        [DataType(DataType.Time)]
        [DisplayName("Time to Complete Task")]
        public DateTime? TotalTimeSpent { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Completion Date")]
        public DateTime? CompletionDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        public CurrentStatus Current_Status { get; set; }

        [DefaultValue(false)]
        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }
    }

}
