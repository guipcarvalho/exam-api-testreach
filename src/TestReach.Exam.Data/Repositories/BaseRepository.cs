using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReach.Exam.Core.Data;

namespace TestReach.Exam.Data.Repositories
{
    public abstract class BaseRepository<T>
        where T : class, IEntity 
    {
        public abstract DbSet<T> GetDbSet();

        public void Add(T entity)
        {
            GetDbSet().Add(entity);
        }
    }
}
