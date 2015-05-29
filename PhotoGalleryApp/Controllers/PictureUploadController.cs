using PhotoGalleryApp.Database;
using System.Web;
using System.Web.Mvc;
using System;
using PhotoGalleryApp.Models;

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
					PhotoStore photoStore = new PhotoStore
					{
						FileName = selectedFile.FileName,
						Image = photoBytes,
						Id = randIndex
					};

					context.PhotoStores.Add(photoStore);
					context.SaveChanges();
				}

				var imageUploaded = FetchImage(randIndex);

				var imageViewModel = new ImageModel
				{
					Base64 = Convert.ToBase64String(imageUploaded.Image),
					FileName = imageUploaded.FileName,
					Id = imageUploaded.Id
				};
				return Json(imageViewModel); 
			}
			catch (System.Exception)
			{
				throw;
			}
		}


		public PhotoStore FetchImage(int id = 0)
		{
			try
			{
				using (var context = new PhotoAppContext())
				{
					var file = context.PhotoStores.Find(id);
					if (file != null)
					{
						return file;
					}

					return null;
				}
			}
			catch (System.Exception)
			{

				throw;
			}
		}
	}
}