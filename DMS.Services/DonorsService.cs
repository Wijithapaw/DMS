using DMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.Domain.Dtos;
using DMS.Data;

namespace DMS.Services
{
    public class DonorsService : IDonorsService
    {
        private DataContext _dataContext;

        public DonorsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(PersonDto donor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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

        public void Update(PersonDto person)
        {
            throw new NotImplementedException();
        }
    }
}
