using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;
using Todo.Infrastructure.Data.Context;

namespace Todo.Infrastructure.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
          where TEntity : BaseEntity
    {
        public DbSet<TEntity> Entity { get; set; }

        private DbContext _context;
        public BaseRepository(DbContext dbContext)
        {
            this._context = dbContext;
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Set<TEntity>().Remove(SelectById(id));
            _context.SaveChanges();
        }

        public IList<TEntity> SelectAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity SelectById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        
    }
}
