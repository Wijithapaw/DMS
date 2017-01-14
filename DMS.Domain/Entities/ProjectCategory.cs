using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Domain.Entities
{
    public class ProjectCategory: BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        [Required]
        [MaxLength(30)]
        public string ShortDescription { get; set; }
    }
}
