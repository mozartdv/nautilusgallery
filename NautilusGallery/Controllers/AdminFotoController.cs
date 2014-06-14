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


        public ActionResult AddAlbum()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddAlbum(string opisanie)
        {
            using (mozartdv_34Entities de = new mozartdv_34Entities())
            {
                GalleryAlbum ga = new GalleryAlbum();
                ga.Text = opisanie;
                de.GalleryAlbum.Add(ga);
                de.SaveChanges();
                return RedirectToAction("EditAlbum/" + ga.Id, "AdminFoto");
            }
            return View();
        }
       [HttpGet]
        public ActionResult EditAlbum(int id)
        {
            List<GalleryFoto> lgf = new List<GalleryFoto>();
            using (mozartdv_34Entities de=new mozartdv_34Entities())
            {
                var data = de.GalleryFoto.Where(x => x.Id_Album == id).ToList();
                foreach (var item in data)
                {
                    lgf.Add(item);
                }

                GalleryAlbum opisanie = de.GalleryAlbum.Where(x => x.Id == id).FirstOrDefault();
                ViewBag.Opisanie = opisanie.Text;
            }
            ViewBag.FotoList = lgf;
            ViewBag.IdAlbum = id;
           return View();
        }
  

        [HttpPost]
        public ActionResult EditAlbum(int id, string Opisanie, HttpPostedFileBase[] file)
        {
            using (mozartdv_34Entities de = new mozartdv_34Entities())
            {
                GalleryAlbum ga = de.GalleryAlbum.Where(x => x.Id == id).First();
                ga.Text = Opisanie;
                de.SaveChanges();
                
                    foreach (var item in file)
                    {
                        if (item != null && item.ContentLength > 0)
                        {
                            string path = System.IO.Path.Combine(Server.MapPath("~/Content/UploadImage"), System.IO.Path.GetFileName(item.FileName));
                            item.SaveAs(path);
                            GalleryFoto gf = new GalleryFoto();
                            gf.Id_Album = id;
                            gf.PathImage = item.FileName;
                             de.GalleryFoto.Add(gf);
                            de.SaveChanges();
                            
                        }
                    
                    
                    }
                

                
                
            }

            return RedirectToAction("EditAlbum/" + id, "AdminFoto");
        }

        public ActionResult DeleteFoto(int IdFoto, int IdAlbum)
        {
            using (mozartdv_34Entities de = new mozartdv_34Entities())
            {
                GalleryFoto gf = de.GalleryFoto.Where(x => x.Id == IdFoto).First();
                string fullPath = Request.MapPath("~/Content/UploadImage/" + gf.PathImage);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                    de.GalleryFoto.Remove(gf);
                    de.SaveChanges();
                    
                }
            
            }

           return RedirectToAction("EditAlbum/" + IdAlbum, "AdminFoto");
        }

        public ActionResult DeleteAlbum(int id)
        {
            using (mozartdv_34Entities de=new mozartdv_34Entities())
            {
                List<GalleryFoto> lgf = de.GalleryFoto.Where(x => x.Id_Album == id).ToList();
                foreach (var item in lgf)
                {
                    string fullPath = Request.MapPath("~/Content/UploadImage/" + item.PathImage);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                        de.GalleryFoto.Remove(item);
                        de.SaveChanges();
                    
                    }
                    
                }
                GalleryAlbum ga = de.GalleryAlbum.Where(x => x.Id == id).First();
                de.GalleryAlbum.Remove(ga);
                de.SaveChanges();
            }
            return RedirectToAction("Index", "AdminFoto");
        }
    }
}
