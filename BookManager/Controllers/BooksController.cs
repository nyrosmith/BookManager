using System.Web.Mvc;
using BookManager.Models;
using BookManager.Repositories.Interfaces;

namespace BookManager.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository repository;

        public BooksController(IBookRepository booksRepository)
        {
            repository = booksRepository;
        }
        //
        // GET: /Books/

        public ActionResult Index()
        {
            return View(repository.GetAll<Book>());
        }

        //
        // GET: /Books/Details/5

        public ActionResult Details(long id = 0)
        {
            var book = repository.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Books/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Books/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.Create(book);
 
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //
        // GET: /Books/Edit/5

        public ActionResult Edit(long id = 0)
        {
            var book = repository.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Books/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.Save(book);

                return RedirectToAction("Index");
            }
            return View(book);
        }

        //
        // GET: /Books/Delete/5

        public ActionResult Delete(long id = 0)
        {
            var book = repository.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Books/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repository.Delete(id);

            return RedirectToAction("Index");
        }

        
    }
}