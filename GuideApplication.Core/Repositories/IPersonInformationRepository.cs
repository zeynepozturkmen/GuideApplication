using GuideApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideApplication.Core.Repositories
{
        //PersonInformation tablosunda crud işlemleri yapabilmek için baseRepository'den inherit alınıyor
        public interface IPersonInformationRepository : IRepository<PersonInformation>
        {
        }
}
