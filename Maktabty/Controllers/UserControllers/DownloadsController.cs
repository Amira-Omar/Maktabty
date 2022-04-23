using Maktabty.Models;
using Maktabty.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Maktabty.Controllers.UserControllers
{
    public class DownloadsController : Controller
    {
        IDownloadsRepo downloadsRepo;

        public DownloadsController(IDownloadsRepo _downloadsRepo)
        {
            downloadsRepo = _downloadsRepo;
        }
        public IActionResult Downloads(string id)
        {
            List<Book> downloads = downloadsRepo.GetUserDownloadsByID(id);
            return View("Downloads",downloads);
        }
    }
}
