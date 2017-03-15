using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Domain.Dtos
{
    public class ProjectCategoryDto
    {
        public int Id { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }
    }
}
