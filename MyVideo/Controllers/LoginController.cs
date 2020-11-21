using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVideo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]//方法忽略验证
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]//方法忽略验证
        public JsonResult CheckUserInfo()
        {
            string name = Request["name"].ToString();
            string pwd = Request["pwd"].ToString();
            if(pwd=="123")
            {
                Session["CurrentUser"] = name;
                return Json(new { res="OK"});
            }
            else
            {
                return Json(new { res = "Fail" });
            }
        }
        public ActionResult Jump()
        {
            return RedirectToAction("Index", "Home");
        }
        public JsonResult Logoff()
        {
            Session["CurrentUser"] = null;
            return Json(new { res = "OK" });
        }
    }
}