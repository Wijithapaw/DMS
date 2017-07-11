using DMS.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using DMS.Domain.Dtos;
using DMS.Data;
using DMS.Data.Entities;

namespace DMS.Services
{
    public class DonorsService : IDonorsService
    {
        private DataContext _dataContext;

        public DonorsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(PersonDto donorDto)
        {
            var donor = new Donor
            {
                FirstName = donorDto.FirstName,
                LastName = donorDto.LastName,
                Email = donorDto.Email,
                Birthday = donorDto.Birthday,
                Active = true
            };

            _dataContext.Donors.Add(donor);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var donor = _dataContext.Donors.Find(id);
            _dataContext.Donors.Remove(donor);
            _dataContext.SaveChanges();
        }

        public PersonDto Get(int id)
        {
            var donor = _dataContext.Donors
                .Where(d => d.Id == id)
                .Select(d => new PersonDto
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Birthday = d.Birthday,
                    Email = d.Email
                }).FirstOrDefault();

            return donor;
        }

        public ICollection<PersonDto> GetAll()
        {
            var donors = _dataContext.Donors.Select(d => new PersonDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Birthday = d.Birthday,
                Email = d.Email
            }).ToList();

            return donors;
        }

        public void Update(PersonDto donorDto)
        {
            var donor = _dataContext.Donors.Find(donorDto.Id);

            donor.FirstName = donorDto.FirstName;
            donor.LastName = donorDto.LastName;
            donor.Email = donorDto.Email;
            donor.Birthday = donorDto.Birthday;

            _dataContext.SaveChanges();
        }
    }
}
