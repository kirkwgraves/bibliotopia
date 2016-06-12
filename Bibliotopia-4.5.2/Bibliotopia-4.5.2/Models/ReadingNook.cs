using Bibliotopia_4._5._2.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Bibliotopia_4._5._2.Models
{
    public class ReadingNook
    {
        public int ReadingNookId { get; set; }
        public ApplicationUser Owner { get; set; }
        public virtual List<FavoriteBook> FavoriteBooks { get; set; }
        public virtual List<ToReadBook> ToReadBooks { get; set; }

    }
}