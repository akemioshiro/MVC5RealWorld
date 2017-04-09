using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC5RealWorld.Models.ViewModel;
using MVC5RealWorld.Models.EntityManager;

namespace MVC5RealWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Welcome()
        {
            return View();
        }

        //[AuthorizeRoles("Admin")]
        [Authorize(Roles = "Admin")]
        public ActionResult AdminOnly()
        {
            return View();
        }

        public ActionResult UnAuthorized()
        {
            return View();
        }

        [Authorize(Roles="Admin")]
        public ActionResult ManageUserPartial()
        {
            if (User.Identity.IsAuthenticated)
            {
                string loginName = User.Identity.Name;
                UserManager UM = new UserManager();
                UserDataView UDV = UM.GetUserDataView(loginName);
                return PartialView(UDV);
            }
            return View();
        }

    }
}