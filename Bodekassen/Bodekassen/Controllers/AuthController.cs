using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bodekassen.Attributes;
using Bodekassen.DB;
using System.Threading.Tasks;

namespace Bodekassen.Controllers
{
    public class AuthController : Controller
    {
        BodekassenDBContainer db = new BodekassenDBContainer();
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FacebookRegister(string facebookId, string firstName, string lastName)
        {
            User user = db.UserSet.SingleOrDefault(u => u.FacebookId == facebookId);
            if(user == null)
            {
                Team[] teams = { };
                User u = db.UserSet.Add(new User { FirstName = firstName, LastName = lastName, FacebookId = facebookId, Teams = teams});

                db.SaveChanges();
                return Json(new { status = "success" });
            }
            return Json(new { state = "user allready exists" });
        }

        [HttpPost]
        public ActionResult FacebookLogin(string facebookId)
        {
            User user = db.UserSet.SingleOrDefault(u => u.FacebookId == facebookId);

            if (user == null)
            {
                Response.StatusCode = 406;
                return Json(new { State = "user not found" });
            }

            return Json(new { FirstName = user.FirstName, LastName = user.LastName, Teams = user.Teams });
        }
    }

}