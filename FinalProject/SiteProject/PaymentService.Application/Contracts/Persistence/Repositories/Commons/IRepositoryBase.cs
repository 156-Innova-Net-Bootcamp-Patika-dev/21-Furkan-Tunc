using PaymentService.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Contracts.Persistence.Repositories.Commons
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        IReadOnlyList<T> GetAll();
        T GetFilterBy(Expression<Func<T, bool>> predicate);
        T GetById(string Id);
        void Add(T entity);
        void Update(T entity, string Id);
        void Remove(string Id);
    }
}
