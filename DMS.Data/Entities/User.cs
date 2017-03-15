using System;
using System.ComponentModel.DataAnnotations;

namespace DMS.Data.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(500)]
        public string Email { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
