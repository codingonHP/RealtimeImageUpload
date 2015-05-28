using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGalleryApp.Controllers
{
    public class PictureUploadController : Controller
    {
        // GET: PictureUpload
        public ActionResult Index()
        {
            return View();
        }
    }
}