using Maktabty.Models;
using System.Collections.Generic;

namespace Maktabty.Repositories
{
    public interface IFavListRepo
    {
        List<Book> GetUserFavsByID(string id);
    }
}