using DMS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Tests
{
    public class Helper
    {
        public static DbContextOptions<DataContext> GetContextOptions()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;

            return options;
        }
    }
}
