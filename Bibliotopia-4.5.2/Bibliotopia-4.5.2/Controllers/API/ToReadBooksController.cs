using Bibliotopia_4._5._2.DAL;
using Bibliotopia_4._5._2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Bibliotopia_4._5._2.Controllers.API
{
    public class ToReadBooksController : ApiController
    {
        private BibliotopiaRepository repo = new BibliotopiaRepository();

        // GET api/ToReadBooks
        public IQueryable<ToReadBook> GetToReadBooks()
        {
            var user_id = User.Identity.GetUserId();
            var to_read_books = repo.GetFavoriteBookCollectionForNook(user_id);
            return (IQueryable<ToReadBook>)to_read_books;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/ToReadBooks
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostToReadBook(Book toReadBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user_id = User.Identity.GetUserId();
            repo.AddBookToReadBookList(user_id, toReadBook);

            return Ok();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}