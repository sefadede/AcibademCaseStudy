using AcibademCaseStudy.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcibademCaseStudy.Repository
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private CaseStudayContext _context;
        private DbSet<T> _entities;

        public Repository(CaseStudayContext context)
        {
            _context = context;
        }

        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());

        public IQueryable<T> Table => Entities;

        public IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        public void Create(T entity)
        {
            Entities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return Entities.Find(id);
        }


        public void Update(T entity)
        {
            Entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
