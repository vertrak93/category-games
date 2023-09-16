using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCategory.Infrastructure.Repositories
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Get();

        public TEntity Get(int id);

        public void Add(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(int id);

        public void Save();
    }
}
