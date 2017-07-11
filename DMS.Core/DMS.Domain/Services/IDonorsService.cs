using DMS.Domain.Dtos;
using System.Collections.Generic;

namespace DMS.Domain.Services
{
    public interface IDonorsService
    {
        void Create(PersonDto donor);

        void Delete(int id);

        PersonDto Get(int id);

        ICollection<PersonDto> GetAll();

        void Update(PersonDto person);
    }
}
