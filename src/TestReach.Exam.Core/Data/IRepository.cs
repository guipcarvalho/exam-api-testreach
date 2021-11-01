using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReach.Exam.Core.Data
{
    public interface IRepository<T> : IDisposable
        where T : class, IEntity
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(T entity);
    }
}
