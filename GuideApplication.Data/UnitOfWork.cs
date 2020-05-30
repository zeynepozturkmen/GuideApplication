using GuideApplication.Core;
using GuideApplication.Core.Repositories;
using GuideApplication.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuideApplication.Data
{
    //UnitOfWork interface metodları yazıldı
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GuideApplicationDbContext _context;
        private PersonInformationRepository _personRepository;

        public UnitOfWork(GuideApplicationDbContext context)
        {
            this._context = context;
        }

        public IPersonInformationRepository Persons => _personRepository = _personRepository ?? new PersonInformationRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
