using DMS.Data;
using DMS.Data.Entities;
using DMS.Domain.Dtos;
using DMS.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace DMS.Tests
{
    public class DonorServiceTests
    {
        public class Delete
        {
            [Theory]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            public void WhenExistingDonor_DeleteSuccessfully(int id)
            {
                var options = Helper.GetContextOptions();

                CreateTestDonors(options);

                using (var context = new DataContext(options))
                {
                    var service = new DonorsService(context);

                    var donorBeforeDelete = service.Get(id);
                    Assert.NotNull(donorBeforeDelete);

                    service.Delete(id);

                    var deletedDonor = service.Get(id);
                    Assert.Null(deletedDonor);
                }
            }

            [Theory]
            [InlineData(100)]
            [InlineData(200)]
            [InlineData(300)]
            public void WhenNonExistingDonor_ThrowsException(int id)
            {
                var options = Helper.GetContextOptions();

                CreateTestDonors(options);

                using (var context = new DataContext(options))
                {
                    var service = new DonorsService(context);

                    Assert.Throws<ArgumentNullException>(() => service.Delete(id));
                }
            }
        }

        public class Create
        {
            [Theory]
            [InlineData("Saman","Kumara","saman@yopmail.com", "1990-1-1")]
            [InlineData("Anjan", "Malik", "anjan.malik@yopmail.com", "1960-1-1")]
            public void WhenPassingCorrectDate_SuccessfullyCreate(string firstName, string lastName, string email, DateTime birthday)
            {
                var options = Helper.GetContextOptions();

                CreateTestDonors(options);

                using (var context = new DataContext(options))
                {
                    var service = new DonorsService(context);

                    var donor = new PersonDto
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        Birthday = birthday
                    };

                    service.Create(donor);

                    var newDonor = service.GetAll().Where(d => d.Email == email).FirstOrDefault();

                    ValidateDonor(newDonor, null, firstName, lastName, email, birthday);
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
        
        public class Update
        {
            [Theory]
            [InlineData(1, "Athula", "Kumara", "athula@yopmail.com", "1990-1-1")]
            [InlineData(1, "Chamara", "Agith", "cham.ajith@yopmail.com", "1960-1-1")]
            public void WhenUpdatingExistingDonor_SuccessfullyUpdate(int id, string firstName, string lastName, string email, DateTime birthday)
            {
                var options = Helper.GetContextOptions();

                CreateTestDonors(options);

                using (var context = new DataContext(options))
                {
                    var service = new DonorsService(context);

                    var donor = new PersonDto
                    {
                        Id = id,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        Birthday = birthday
                    };

                    service.Update(donor);

                    var newDonor = service.Get(id);

                    ValidateDonor(newDonor, id, firstName, lastName, email, birthday);
                }
            }

            [Theory]
            [InlineData(100, "Athula", "Kumara", "athula@yopmail.com", "1990-1-1")]
            [InlineData(200, "Chamara", "Agith", "cham.ajith@yopmail.com", "1960-1-1")]
            public void WhenUpdatingNonExistingDonor_ThrowsException(int id, string firstName, string lastName, string email, DateTime birthday)
            {
                var options = Helper.GetContextOptions();

                CreateTestDonors(options);

                using (var context = new DataContext(options))
                {
                    var service = new DonorsService(context);

                    var donor = new PersonDto
                    {
                        Id = id,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        Birthday = birthday
                    };

                    Assert.Throws<NullReferenceException>(() => service.Update(donor));
                }
            }
        }

        #region Private Methods

        private static Donor CreateNewDonor(string firstName, string lastName, DateTime birthday, string email)
        {
            return new Donor
            {
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

                context.Donors.Add(CreateNewDonor("Wijitha", "Wijenayake", new DateTime(1985, 8, 1), "wijitha@yopmail.com"));
                context.Donors.Add(CreateNewDonor("Widura", "Wijenayake", new DateTime(1990, 8, 1), "widura@yopmail.com"));
                context.Donors.Add(CreateNewDonor("Wickrama", "Wijenayake", new DateTime(1983, 8, 5), "wickrama@yopmail.com"));
                context.SaveChanges();
            }
        }

        private static void ValidateDonor(PersonDto donor, int? id, string firstName, string lastName, string email, DateTime birthday)
        {
            Assert.NotNull(donor);

            if (id != null)
                Assert.Equal(id, donor.Id);

            Assert.Equal(email, donor.Email);
            Assert.Equal(firstName, donor.FirstName);
            Assert.Equal(lastName, donor.LastName);
            Assert.Equal(birthday, donor.Birthday);
        }

        #endregion
    }
}
