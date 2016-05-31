using Bibliotopia.Data;
using Bibliotopia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotopia.DAL
{
    public class BibliotopiaContext : ApplicationDbContext
    {
       
        public BibliotopiaContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ReadingNook> ReadingNooks { get; set; }

    }
}
