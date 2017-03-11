using DMS.Data;
using DMS.Domain.Dtos;
using DMS.Domain.Entities;
using DMS.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DMS.Tests
{
    public class DonorServiceTests
    {
        public static Donor CreateNewDonor(int id, string firstName, string lastName, DateTime birthday, string email)
        {
            return new Donor
            {
                Id  = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Birthday = birthday,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedBy = 1,
                LastUpdatedDateUtc = DateTime.UtcNow
            };
        }

        private static void CreateTestDonors(DbContextOptions<DataContext> options)
        {
            using (var context = new DataContext(options))
            {
                context.Database.EnsureDeleted();

                context.Donors.Add(CreateNewDonor(1, "Wijitha", "Wijenayake", new DateTime(1985, 8, 1), "wijitha@yopmail.com"));
                context.Donors.Add(CreateNewDonor(2, "Widura", "Wijenayake", new DateTime(1990, 8, 1), "widura@yopmail.com"));
                context.Donors.Add(CreateNewDonor(3, "Wickrama", "Wijenayake", new DateTime(1983, 8, 5), "wickrama@yopmail.com"));
                context.SaveChanges();
            }
        }
        //private static bool ValidateDonor(PersonDto donor, out string errorMessage)
        //{
        //    bool valid = true;

        //    Assert.NotNull(donor);
        //    Assert.Equal("wijitha@yopmail.com", donor.Email);
        //    Assert.Equal("Wijitha", donor.FirstName);
        //    Assert.Equal("Wijenayake", donor.LastName);
        //    Assert.Equal(new DateTime(1985, 8, 1), donor.Birthday);
        //}

        public class GetAll
        {
            [Fact]
            public void WhenThereAreDonors_ReturnAll()
            {
                var options = Helper.GetContextOptions();

                CreateTestDonors(options);

                using (var context = new DataContext(options))
                {
                    var service = new DonorsService(context);
                    var donors = service.GetAll();
                    Assert.Equal(3, donors.Count);
                }
            }

            [Fact]
            public void WhenThereAreNoDonors_ReturnNon()
            {
                using (var context = new DataContext(Helper.GetContextOptions()))
                {
                    var service = new DonorsService(context);
                    var donors = service.GetAll();
                    Assert.Equal(0, donors.Count);
                }
            }
        }

        public class Get
        {
            [Theory]
            [InlineData(1, "Wijitha", "Wijenayake", "wijitha@yopmail.com", "1985-8-1")]
            [InlineData(2, "Widura", "Wijenayake", "widura@yopmail.com", "1990-8-1")]
            [InlineData(3, "Wickrama", "Wijenayake", "wickrama@yopmail.com", "1983-8-5")]
            public void WhenValidIdGiven_RetunrsDonor(int id, string firstName, string lastName, string email, DateTime birthDay)
            {
                var options = Helper.GetContextOptions();

                CreateTestDonors(options);

                using (var context = new DataContext(options))
                {
                    var service = new DonorsService(context);
                    var donor = service.Get(id);

                    Assert.NotNull(donor);
                    Assert.Equal(email, donor.Email);
                    Assert.Equal(firstName, donor.FirstName);
                    Assert.Equal(lastName, donor.LastName);
                    Assert.Equal(birthDay, donor.Birthday);
                }
            }

            [Theory]
            [InlineData(101)]
            [InlineData(102)]
            [InlineData(103)]
            public void WhenInValidIdGiven_ReturnsNon(int id)
            {
                var options = Helper.GetContextOptions();

                CreateTestDonors(options);

                using (var context = new DataContext(options))
                {
                    var service = new DonorsService(context);
                    var donor = service.Get(id);

                    Assert.Null(donor);                   
                }
            }
        }
    }
}
