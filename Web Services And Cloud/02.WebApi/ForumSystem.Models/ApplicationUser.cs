using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ForumSystem.Models
{

    public class ApplicationUser : IdentityUser
    {
        //public ApplicationUser()
        //{
        //    this.purchases = new HashSet<Purchase>();
        //}

        //[Required]

        //public Guid UserId { get; set; }

        //[Required]
        //[MaxLength(100)]
        //public string FirstName { get; set; }

        //[Required]
        //[MaxLength(100)]
        //public string LastName { get; set; }

        //[Required]
        //public byte Level { get; set; }

        //[Required]
        //public DateTime JoinDate { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            return userIdentity;
        }
    }
}
