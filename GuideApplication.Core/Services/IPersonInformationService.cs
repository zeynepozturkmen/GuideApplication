using GuideApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuideApplication.Core.Services
{
    public interface IPersonInformationService
    {
        //Crud işlemlerini controller'da yapmak yerine service yazılıp,controllerda cagırılıyor
        Task<IEnumerable<PersonInformation>> GetAllPersons();
        Task<PersonInformation> GetPersonById(int id);
        Task<PersonInformation> CreatePerson(PersonInformation newPerson);
        Task UpdatePerson(PersonInformation person);
        Task DeletePerson(PersonInformation person);
    }
}
