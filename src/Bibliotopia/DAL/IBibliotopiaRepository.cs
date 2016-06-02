using Bibliotopia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotopia.DAL
{
    public interface IBibliotopiaRepository
    {
        IEnumerable<Book> GetAllBooks();
        ReadingNook GetUserReadingNook(ApplicationUser user);
        Book GetSpecificBook(int bookId);
    }
}
