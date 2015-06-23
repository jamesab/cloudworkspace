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
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Note")]
        public string Note_Comment { get; set; }
        [Required]
        public string Topic { get; set; }

              
        [ScaffoldColumn(false)]
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        [DefaultValue(false)]
        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }
        [DisplayName("Created By")]
        public string UserName { get; set; }

        [DisplayName("Project")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public CloudWorkSpace.DAL.DTO.Project Projects { get; set; }
    }
}
