using BusinessLogic.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;



namespace MyApi01.Controllers
{
    public class BookController : ApiController
    {
        // GET: api/Book
        public List<Book> GetBooks()
        {
            BookDBOperation bookDBOperation = new BookDBOperation();
            return BookDBOperation.GetBooks();
            
        }

        // GET: api/Book/5
        public Book GetBook(int id)
        {
            //Book book = new Book();
            //List<Book> books = BookDBOperation.GetBooks();
            //book = books.Find(x => x.BookID == id);
            //return book;

             return BookDBOperation.GetBook(id);
        }

        // POST: api/Book
        public void Post(Book book)
        {
            //Option 1:
           // book.CreatedOn = System.DateTime.Now;
            //book.UpdatedOn = System.DateTime.Now;
            BookDBOperation.AddBook(book);
        }

        // PUT: api/Book/5
        public void Put(Book book)
        {
            BookDBOperation.UpdateBook(book);
        }

        // DELETE: api/Book/5
        public void Delete(int id)
        {
            BookDBOperation.DeleteBook(id);
        }
    }
}
