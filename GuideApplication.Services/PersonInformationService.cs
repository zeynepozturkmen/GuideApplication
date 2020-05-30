using GuideApplication.Core;
using GuideApplication.Core.Models;
using GuideApplication.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideApplication.Services
{
    public class PersonInformationService : IPersonInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonInformationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<PersonInformation> CreatePerson(PersonInformation newPerson)
        {
            await _unitOfWork.Persons
                .AddAsync(newPerson);

            return newPerson;
        }

        public async Task DeletePerson(PersonInformation person)
        {
            var findPerson = _unitOfWork.Persons.Where(x => x.Id == person.Id).FirstOrDefault();
            findPerson.IsDeleted = true;

            _unitOfWork.Persons.Update(findPerson);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<PersonInformation>> GetAllPersons()
        {
            return await _unitOfWork.Persons.GetAllAsync();
        }

        public async Task<PersonInformation> GetPersonById(int id)
        {
            return await _unitOfWork.Persons.GetByIdAsync(id);
        }

        public async Task UpdatePerson(PersonInformation person)
        {
            var findPerson = _unitOfWork.Persons.Where(x => x.Id == person.Id).FirstOrDefault();

            findPerson.FullName = person.FullName;
            findPerson.PhoneNumber = person.PhoneNumber;
            findPerson.Email = person.Email;
            findPerson.UpdateDate = person.UpdateDate;

            _unitOfWork.Persons.Update(findPerson);

            await _unitOfWork.CommitAsync();
        }

    }
}
