using GuideApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuideApplication.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //Tüm repository'lere tek bir yerden ulaşanilmek için unitOfWork kullanılıyor.
        IPersonInformationRepository Persons { get; }
        Task<int> CommitAsync();
    }
}
