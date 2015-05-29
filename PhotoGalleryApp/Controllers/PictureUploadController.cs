using PhotoGalleryApp.Database;
using System.Web;
using System.Web.Mvc;

namespace PhotoGalleryApp.Controllers
{
	public class PictureUploadController : Controller
    {
        // GET: PictureUpload
        public ActionResult Dashboard()
        {
            return View();
        }

		public ActionResult SaveImage(HttpPostedFileBase selectedFile)
		{
			byte[] photoBytes = new byte[selectedFile.ContentLength];
			int randIndex = System.DateTime.Now.Millisecond + new System.Random(100).Next();
            try
			{
				if (selectedFile.InputStream.CanRead)
				{
					selectedFile.InputStream.Position = 0;
					selectedFile.InputStream.Read(photoBytes, 0, selectedFile.ContentLength);
				}
				
				using (var context = new PhotoAppContext())
				{
					PhotoStore photoStore = new PhotoStore {
						FileName = selectedFile.FileName,
					    Image = photoBytes,
						Id = randIndex
					};

					context.PhotoStores.Add(photoStore);
					context.SaveChanges();
				}


				return RedirectToActionPermanent("PictureUpload", "FetchImage", new { id = randIndex });
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		public FileContentResult FetchImage(int id = 0)
		{
			try
			{
				using (var context = new PhotoAppContext())
				{
					return null; //work under progress.
				}
			}
			catch (System.Exception)
			{

				throw;
			}
		}
    }
}