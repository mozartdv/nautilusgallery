using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NautilusGallery.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            List<GalleryAlbum> listga = new List<GalleryAlbum>();
            using (mozartdv_34Entities de = new mozartdv_34Entities())
            {
                var lga = de.GalleryAlbum.ToList();
                foreach (var item in lga)
                {
                    listga.Add(item);
                }
            }
            ViewBag.ListOfAlbum = listga;

            return View();
        }

        public ActionResult Album(int id)
        {

            return Content("Просмотр альбома" + " " + id.ToString());
        }


    }
}
