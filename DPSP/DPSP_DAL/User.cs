using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPSP_DAL
{
    public class User : BasicEntity
    {
        [Index(IsUnique = true),MaxLength(SmallColumnLength)]
        public string AspNetUsersId { get; set; }

        //[Required(ErrorMessage = "Please add first name")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Please add last name")]
        public string LastName { get; set; }

        public UserStatus Status { get; set; }

        [InverseProperty("Users")]
        public virtual ICollection<Project> Projects { get; set; }

        [InverseProperty("Users")]
        public virtual ICollection<Role> Roles { get; set; }
    }

    public enum UserStatus
    {
        Active = 10,
        Disabled = 20,
        Deleted = 30
    }
}
