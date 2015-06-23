using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Platform
    {
        public int PlatformId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
