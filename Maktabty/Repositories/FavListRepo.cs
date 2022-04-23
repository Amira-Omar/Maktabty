using Maktabty.Models;
using System.Collections.Generic;
using System.Linq;

namespace Maktabty.Repositories
{
    public class FavListRepo : IFavListRepo
    {
        DbEntities context;
        public FavListRepo(DbEntities _context)
        {
            context = _context;
        }

        public List<Book> GetUserFavsByID(string id)
        {
            //List<Book> books = new List<Book>();
            //List<Fav> favList = context.Favs.Where(d => Equals(d.UserId, id)).ToList();
            //foreach (var item in favList)
            //{
            //    Book book = context.Books.FirstOrDefault(b => b.Id == item.BookId);
            //    books.Add(book);
            //}
            List<Book> books = context.Favs.Where(d => Equals(d.UserId, id)).Select(b => b.Book).ToList();
            return books;
        }

    }
}
