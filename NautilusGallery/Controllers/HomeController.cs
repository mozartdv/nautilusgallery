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
            

            using ( mozartdv_34Entities db= new mozartdv_34Entities() )
            {
                var ob = db.GalleryAlbum.Where(x => x.Id == 6).FirstOrDefault();
                
            }

            return View();
        }

        public ActionResult Album(int id)
        {

            return Content("Просмотр альбома" + " " + id.ToString());
        }


    }
}
