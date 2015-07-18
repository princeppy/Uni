using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Resource
    {
        public Resource()
        {
            this.Licenses = new HashSet<License>();
        }

        public int ResourceID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
