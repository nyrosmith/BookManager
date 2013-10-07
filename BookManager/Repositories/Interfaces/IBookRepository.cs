using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookManager.Interfaces;

namespace BookManager.Repositories.Interfaces
{
    public interface IBookRepository : IRepository
    {
        object GetById(long id);
        T GetById<T>(long id);

        IList<T> GetAll<T>();
        void Create(object entity);
        void Save(object entity);
        void Delete(long id);
    }
}
