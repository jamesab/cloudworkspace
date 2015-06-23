using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CloudWorkSpace.DAL.DTO
{
    public class Platform
    {
        public int PlatformId { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int ProjectId { get; set; }
        
        [ForeignKey("ProjectId")]
        public Project Projects { get; set; }
    }
}
