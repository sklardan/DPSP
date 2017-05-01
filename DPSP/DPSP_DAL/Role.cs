using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPSP_DAL
{
    public class Role : BasicEntity
    {
        [Required]
        [MaxLength(MediumColumnLength)]
        public string Name { get; set; }

        [Range(0, 1)]
        public RoleType Enum { get; set; }

        public string Description { get; set; }

        [InverseProperty("Roles")]
        public virtual ICollection<User> Users { get; set; }
    }

    public enum RoleType
    {
        [Display(Name = "Employee")]
        Employee = 0,
        [Display(Name = "Client")]
        Client = 1
    }
}
