using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.Models
{
    public class BookToRead
    {
        public virtual int BookToReadId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public virtual Book Book { get; set; }
    }
}