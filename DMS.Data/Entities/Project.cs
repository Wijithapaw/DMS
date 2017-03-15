using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Data.Entities
{
    public class Project : BaseEntity 
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Description { get; set; }

        public virtual ProjectCategory ProjectCategory { get; set; }

        [ForeignKey("ProjectCategory")]
        public int ProjectCategoryId { get; set; }

        public DateTime StartDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }
    }
}
