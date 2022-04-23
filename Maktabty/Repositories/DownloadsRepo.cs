using Maktabty.Models;
using System.Collections.Generic;
using System.Linq;

namespace Maktabty.Repositories
{
    public class DownloadsRepo : IDownloadsRepo
    {
        DbEntities context;

        public DownloadsRepo(DbEntities _context)
        {
            context = _context;
        }
        public List<Book> GetUserDownloadsByID(string id)
        {
        //    List<Book> books = new List<Book>();

        //    List<Downloads> downloads =context.Downloads.Where(d => Equals(d.UserId, id)).ToList();
        //    foreach (var item in downloads)
        //    {
        //        Book book = context.Books.FirstOrDefault(b => b.Id == item.BookId);
        //        books.Add(book);
        //    }
            List<Book> books=context.Downloads.Where(d => Equals(d.UserId, id)).Select(b=>b.Book).ToList();
            return books;
        }

    }
}
