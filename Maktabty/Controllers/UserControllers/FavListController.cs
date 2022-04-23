using Maktabty.Models;
using Maktabty.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Maktabty.Controllers.UserControllers
{
    public class FavListController : Controller
    {
        IFavListRepo favListRepo;

        public FavListController(IFavListRepo _favListRepo)
        {
            favListRepo = _favListRepo;
        }
        public IActionResult FavList(string id)
        {
            List<Book> favs = favListRepo.GetUserFavsByID(id);
            return View("FavList", favs);
        }
    }
}
