using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Bug
    {
        public int BugId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateReported { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FixedDate { get; set; }
        [Required]
        public CurrentStatus CurrentStatus { get; set; }
        [DefaultValue(false)]
        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }
    }
}
