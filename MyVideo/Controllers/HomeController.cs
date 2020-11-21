using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Tools;

namespace MyVideo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> Efiles = new List<string>();
            FileTools.GetFilesByPathAndExt(ref Efiles, @"E:\HD\[11]New", "*.mp4");
            ViewBag.Efiles = Efiles;

            List<string> Ffiles = new List<string>();
            FileTools.GetFilesByPathAndExt(ref Ffiles, @"F:\电影\Movie\[11]New", "*.mp4");
            ViewBag.Ffiles = Ffiles;

            List<string> Gfiles = new List<string>();
            FileTools.GetFilesByPathAndExt(ref Gfiles, @"G:\电影\Movie\[11]New", "*.mp4");
            ViewBag.Gfiles = Gfiles;

            return View();
        }

        public ActionResult Movie(string id)
        {
            ViewBag.Message = id;

            ViewBag.MovieName = id;

            string physicEPath = @"E:\HD\[11]New";
            string physicFPath = @"F:\电影\Movie\[11]New";
            string physicGPath = @"G:\电影\Movie\[11]New";

            string movieNameE = string.Empty;
            FileTools.GetFileFullPathByfileNameAndParentPath(physicEPath, id, ref movieNameE);
            string movieNameF = string.Empty;
            FileTools.GetFileFullPathByfileNameAndParentPath(physicFPath, id, ref movieNameF);
            string movieNameG = string.Empty;
            FileTools.GetFileFullPathByfileNameAndParentPath(physicGPath, id, ref movieNameG);

            if (movieNameE.Contains(physicEPath))
            {
                ViewBag.movieSubPath = "/EVideo/" + movieNameE.Substring(physicEPath.Length);
            }
            else if (movieNameF.Contains(physicFPath))
            {
                ViewBag.movieSubPath = "/FVideo/" + movieNameF.Substring(physicFPath.Length);
            }
            else if (movieNameG.Contains(physicGPath))
            {
                ViewBag.movieSubPath = "/GVideo/" + movieNameG.Substring(physicGPath.Length);
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}