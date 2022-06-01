using Bookstore.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.Controllers
{
    public class BooksController : Controller
    {

        // GET: Books
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult Index()
        {
            try
            {
                var filterBuilder = Builders<Books>.Filter;
                var filter = filterBuilder.Empty;
                List<Books> books = db.BooksCollection.Find(filter).ToList();

                return View(books);

            }
            catch (Exception)
            {
                return View("Error");
            }
            
        }

        // GET: Books/Details/5
        public ActionResult Details(string id)
        {
            var document = db.BooksCollection.Find( x=>x._id==id).FirstOrDefault();               
            return View(document);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Books books)
        {
            try
            {
                db.BooksCollection.InsertOne(books);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(string id)
        {
            var bookId = new ObjectId(id);
            var document = db.BooksCollection.Find(x => x._id == id).FirstOrDefault();
            return View(document);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Books books)
        {
            try
            {
                var filterBuilder = Builders<Books>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<Books>.Update
                    .Set("title", books.title)
                    .Set("description", books.description)
                    .Set("bookQuantity", books.bookQuantity)
                    .Set("category", books.category)
                    .Set("author", books.author)
                    .Set("price", books.price);
                db.BooksCollection.UpdateOne(filterBuilder, update);
                //var result = db.BooksCollection.UpdateOne(filterBuilder, update);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(string id)
        {
            var document = db.BooksCollection.Find(x => x._id == id).FirstOrDefault();
            return View(document);
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Books books)
        {
            try
            {
                db.BooksCollection.DeleteOne(Builders<Books>.Filter.Eq("_id", id));
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
