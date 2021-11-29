using ImgArena.DataStorage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//implementation taken from https://dotnettutorials.net/lesson/generic-repository-pattern-csharp-mvc/
//not an ideal one - lack of async methods - but hopefully good enough to present an idea
namespace ImgArena.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        static bool _seeded = false;
        private ProductDbContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;
            this._context = new ProductDbContext(options);
            table = _context.Set<T>();
        }
        public GenericRepository(ProductDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public T Insert(T obj)
        {
            table.Add(obj);
            _context.SaveChanges();

            return obj;
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
