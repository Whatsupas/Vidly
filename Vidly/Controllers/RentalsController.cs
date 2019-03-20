using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult NewRental()
        {
            return View();
        }
    }
}