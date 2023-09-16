using GameCategory.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCategory.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
     
        private DbTestContext _context;
        private DbSet<TEntity> _entities;
        public Repository(DbTestContext context) 
        { 
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public void Add(TEntity entity) => _entities.Add(entity);

        public void Delete(int id)
        {
            var dbObj = _entities.Find(id);
            Type entityType = typeof(TEntity);
            var mActive = entityType.GetProperty("Active");
            mActive.SetValue(dbObj, false, null);
            _context.Entry(dbObj).State = EntityState.Modified;

        }

        public IEnumerable<TEntity> Get() => _entities.ToList();

        public TEntity Get(int id) => _entities.Find(id);

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
