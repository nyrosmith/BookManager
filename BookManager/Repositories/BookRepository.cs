using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

using BookManager.Interfaces;
using BookManager.Models;
using BookManager.Repositories.Interfaces;

namespace BookManager.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookContext db;

        public BookRepository(BookContext booksDbContext)
        {
            db = booksDbContext;
        }


        public object GetById(long id)
        {
            var book = db.Books.Find(id);
            return book;
        }

        public T GetById<T>(long id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll<T>()
        {
            return db.Books.Cast<T>().ToList();
        }

        public void Save(object book)
        {
            var entity = book as Book;
            if (entity == null)
                throw new ArgumentNullException("entity: Book");

            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(object book)
        {
            var entity = book as Book;
            if (entity == null)
                throw new ArgumentNullException("entity: Book");

            db.Books.Add(entity);
            db.SaveChanges();
        }

        public void Delete(long id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }
    }
}