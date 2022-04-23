using Maktabty.Models;
using System.Collections.Generic;

namespace Maktabty.Repositories
{
    public interface IDownloadsRepo
    {
        List<Book> GetUserDownloadsByID(string id);
    }
}