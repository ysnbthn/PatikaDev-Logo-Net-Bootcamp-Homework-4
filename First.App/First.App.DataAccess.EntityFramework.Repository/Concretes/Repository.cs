using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace First.App.DataAccess.EntityFramework.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly IUnitOfWork unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            
            T exist = unitOfWork.Context.Set<T>().Find(entity.Id);
            
            if (exist != null)
            {
                // stop tracking existing entry
                unitOfWork.Context.Entry(exist).State = EntityState.Detached;
                exist.IsDeleted = true;
                unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public IQueryable<T> Get()
        {
            return unitOfWork.Context.Set<T>().Where(x=> !x.IsDeleted).AsQueryable();
        }

        public void Update(T entity)
        {
            unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
