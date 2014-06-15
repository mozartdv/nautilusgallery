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
            List<GalleryFoto> listgf = new List<GalleryFoto>();
            using (mozartdv_34Entities de = new mozartdv_34Entities())
            {
                var lgf = de.GalleryFoto.Where(x => x.Id_Album == id).ToList();
                foreach (var item in lgf)
                {
                    listgf.Add(item);
                }
            }
            ViewBag.ListOfFoto = listgf;
            
            return View();
        }


    }
}
