using Maktabty.Models;
using Maktabty.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Maktabty.Controllers.UserControllers
{
    public class ProfileController : Controller
    {
        IProfileRepo profileRepo;

        public ProfileController( IProfileRepo _profileRepo)
        {
            profileRepo = _profileRepo;
        }
        public IActionResult UserData( string _id)
        {
            ApplicationUser user = profileRepo.GetUserByID( _id );
            
            return View("UserData", user);
        }
    }
}
