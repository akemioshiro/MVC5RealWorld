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
        //[Authorize(Roles = "Admin")]
        public ActionResult AdminOnly()
        {
            return View();
        }

        public ActionResult UnAuthorized()
        {
            return View();
        }

        //[Authorize(Roles="Admin")]
        public ActionResult ManageUserPartial(string status ="")
        {
            if (User.Identity.IsAuthenticated)
            {
                string loginName = User.Identity.Name;
                UserManager UM = new UserManager();
                UserDataView UDV = UM.GetUserDataView(loginName);

                string message = string.Empty;
                if (status.Equals("update"))
                    message = "Update Successful";
                else if (status.Equals("delete"))
                    message = "Delete Successful";

                ViewBag.Message = message;

                return PartialView(UDV);
            }
            return RedirectToAction("Index", "Home");
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult UpdateUserData(int userId, string loginName, string password, string firstName, string lastName, string gender, int roleId = 0)
        {
            UserProfileView UPV = new UserProfileView();
            UPV.SYSUserID = userId;
            UPV.LoginName = loginName;
            UPV.Password = password;
            UPV.FirstName = firstName;
            UPV.LastName = lastName;
            UPV.Gender = gender;

            if (roleId > 0)
                UPV.LOOKUPRoleID = roleId;

            UserManager UM = new UserManager();
            UM.UpdateUserAccount(UPV);

            return Json(new { success = true  });

        }

    }
}