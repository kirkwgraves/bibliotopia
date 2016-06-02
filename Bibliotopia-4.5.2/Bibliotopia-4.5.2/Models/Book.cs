using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.Models
{
    public class Book
    {
        public virtual int BookId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual string Synopsis { get; set; }
        public virtual string Reaction { get; set; }
        public virtual int ViewerId { get; set; }
        public virtual int ISBN { get; set; }
    }
}