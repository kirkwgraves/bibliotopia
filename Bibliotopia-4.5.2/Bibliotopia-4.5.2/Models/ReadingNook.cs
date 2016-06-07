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
        public virtual int ReadingNookId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public virtual FavoriteBook FavoriteBook { get; set; }
        public virtual ToReadBook ToReadBook { get; set; }

    }
}