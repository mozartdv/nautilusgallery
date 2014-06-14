using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NautilusGallery.Controllers
{
    public class AdminFotoController : Controller
    {
        //
        // GET: /AdminFoto/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddAlbum()
        {

            return View();
        }

       [HttpGet]
        public ActionResult EditAlbum(int id)
        {

            
           return View();
        }
  

        [HttpPost]
        public ActionResult EditAlbum(int id, string Opisanie, HttpPostedFileBase file)
        {
            string path = System.IO.Path.Combine(Server.MapPath("~/Content/UploadImage"), System.IO.Path.GetFileName(file.FileName));
            file.SaveAs(path);
            return RedirectToAction("Index","Home");
        }
    }
}
