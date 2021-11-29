using System;
using System.Collections.Generic;
using System.Text;

//implementation taken from https://dotnettutorials.net/lesson/generic-repository-pattern-csharp-mvc/
//not an ideal one - lack of async methods - but hopefully good enough to present an idea
namespace ImgArena.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
