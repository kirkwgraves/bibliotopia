using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Bibliotopia_4._5._2.DAL;
using Bibliotopia_4._5._2.Models;
using Microsoft.AspNet.Identity;

namespace Bibliotopia_4._5._2.Controllers.API
{
    public class FavoriteBooksController : ApiController
    {
        private BibliotopiaRepository repo = new BibliotopiaRepository();

        // GET: api/FavoriteBooks
        public IQueryable<FavoriteBook> GetFavoriteBooks()
        {
            var user_id = User.Identity.GetUserId();
            var faves = repo.GetFavoriteBookCollectionForNook(user_id);
            return (IQueryable<FavoriteBook>)faves;
        }
    }
}

//        // GET: api/FavoriteBooks/5
//        [ResponseType(typeof(FavoriteBook))]
//        public IHttpActionResult GetFavoriteBook(int id)
//        {
//            if (favoriteBook == null)
//            {
//                return NotFound();
//            }

//            return Ok(favoriteBook);
//        }

//        // PUT: api/FavoriteBooks/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult PutFavoriteBook(int id, FavoriteBook favoriteBook)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != favoriteBook.FavoriteBookId)
//            {
//                return BadRequest();
//            }


//            try
//            {
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!FavoriteBookExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/FavoriteBooks
//        [ResponseType(typeof(Book))]
//        public IHttpActionResult PostFavoriteBook(Book favoriteBook)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
            
            
//            repo.AddBookToFavorites(favoriteBook);
//            db.SaveChanges();

//            return CreatedAtRoute("DefaultApi", new { id = favoriteBook.FavoriteBookId }, favoriteBook);
//        }

//        // DELETE: api/FavoriteBooks/5
//        [ResponseType(typeof(FavoriteBook))]
//        public IHttpActionResult DeleteFavoriteBook(int id)
//        {
//            FavoriteBook favoriteBook = db.FavoriteBooks.Find(id);
//            if (favoriteBook == null)
//            {
//                return NotFound();
//            }

//            db.FavoriteBooks.Remove(favoriteBook);
//            db.SaveChanges();

//            return Ok(favoriteBook);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool FavoriteBookExists(int id)
//        {
//            return db.FavoriteBooks.Count(e => e.FavoriteBookId == id) > 0;
//        }
//    }
//}