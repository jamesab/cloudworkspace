using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Task
    {
        public int TaskId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string TaskName { get; set; }
        [DataType(DataType.Time)]
        public DateTime TotalTimeSpent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CompletionDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        public CurrentStatus Current_Status { get; set; }
        [DefaultValue(false)]
        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }
    }

}
