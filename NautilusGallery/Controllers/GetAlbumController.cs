using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NautilusGallery.Controllers
{
    public class GetAlbumController : Controller
    {
        //
        // GET: /GetAlbum/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Preview(int id)
        {
            using (mozartdv_34Entities de = new mozartdv_34Entities())
            {
                GalleryFoto firstfotofromalbum = de.GalleryFoto.Where(x => x.Id_Album == id).FirstOrDefault();
                if (firstfotofromalbum!=null)
                {
                    var dir = Server.MapPath("~/Content/UploadImage");
                    var path = Path.Combine(dir, firstfotofromalbum.PathImage);
                    return base.File(path, "image");
                }
            }
            return View();
        }

        public ActionResult Main(int id)
        {
            using (mozartdv_34Entities de = new mozartdv_34Entities())
            {
                
                ViewBag.Image = "/GetAlbum/Preview/"+id;
                GalleryAlbum ga = de.GalleryAlbum.Where(x => x.Id == id).First();
                ViewBag.Opisanie = ga.Text;
                ViewBag.Id = ga.Id;
            }

            return PartialView();
        }
    }
}
