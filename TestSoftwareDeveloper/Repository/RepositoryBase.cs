using System.Linq.Expressions;
using TestSoftwareDeveloper.Contracts;
using TestSoftwareDeveloper.Entities;

namespace TestSoftwareDeveloper.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll() => _repositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _repositoryContext.Set<T>().Where(expression);

        public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);

        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);
    }
}
