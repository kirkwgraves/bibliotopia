﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string GoogleBookId { get; set; }
    }
}