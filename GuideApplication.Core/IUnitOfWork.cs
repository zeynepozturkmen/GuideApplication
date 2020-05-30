using GuideApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuideApplication.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //Bir iş birimi, bir işlem sırasında değişikliklerin listesini takip etmek ve işlemden sorumludur.
        //Tüm repository'lere tek bir yerden ulaşabilmek için unitOfWork kullanılıyor.Oluşturdugumuz diger tabloların repository'lerini de buraya eklemeliyiz.
        IPersonInformationRepository Persons { get; }
        Task<int> CommitAsync();
    }
}
