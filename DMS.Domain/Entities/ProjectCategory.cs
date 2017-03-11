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
        [MaxLength(50)]
        public string ShortDescription { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
