using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.Models
{
    public class ToReadBook
    {
        public int ToReadBookId { get; set; }
        public ReadingNook ReadingNook { get; set; }
        public virtual Book Book { get; set; }
    }
}