using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuideApplication.Core.Repositories
{

    //Basit bir deyişle, tek bir yerde veritabanı işlemleri (ORM veya veritabanı erişimi diğer yöntemlerle) enkapsüle edilir. Temel olarak veri erişim katmanını soyutlama. 

    //RepositoryPattern kullanımında tüm repository'lerde crud işlemlerinin tekrarlanmaması için baseRepository yazıldı
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetById(int id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
