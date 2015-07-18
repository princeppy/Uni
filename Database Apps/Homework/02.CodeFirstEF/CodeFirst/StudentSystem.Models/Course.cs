using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
            this.Homeworks = new HashSet<Homework>();
            this.Resources = new HashSet<Resource>();
        }
        
        public int CourseID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
