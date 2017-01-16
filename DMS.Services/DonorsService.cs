using DMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.Domain.Dtos;

namespace DMS.Services
{
    public class DonorsService : IDonorsService
    {
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
            throw new NotImplementedException();
        }

        public ICollection<PersonDto> GetAll()
        {
            List<PersonDto> donors = new List<PersonDto>();
            donors.Add(new PersonDto { Id = 1, FirstName = "Wijitha", LastName = "Wijenayake", Email = "wijitha@yopmail.com", Birthday = new DateTime(1985, 8, 1) });
            donors.Add(new PersonDto { Id = 2, FirstName = "Widura", LastName = "Wijenayake", Email = "widura@yopmail.com", Birthday = new DateTime(1990, 8, 8) });
            donors.Add(new PersonDto { Id = 3, FirstName = "Wickrama", LastName = "Wijenayake", Email = "wickrama@yopmail.com", Birthday = new DateTime(1983, 7, 12) });

            return donors;
        }

        public void Update(PersonDto person)
        {
            throw new NotImplementedException();
        }
    }
}
