﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.Models
{
    public class BookToRead
    {
        public int BookToReadId { get; set; }
        public Book Book { get; set; }
        public ReadingNook ReadingNook { get; set; }
    }
}