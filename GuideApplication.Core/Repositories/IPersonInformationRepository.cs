using GuideApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideApplication.Core.Repositories
{
        //PersonInformation tablosunda crud işlemleri yapabilmek için baseRepository'den inherit alınıyor

        //Standart crud işlemleri dısında, PersonInformation tablomuza özgü, mesela aynı soyismi içeren tüm kayıtları getirmek gibi bir metod yazmak isteyebiliriz.Bu tablomuza özel metodlarımızı kendi interface'inde yazabiliriz.
        public interface IPersonInformationRepository : IRepository<PersonInformation>
        {
        }
}
