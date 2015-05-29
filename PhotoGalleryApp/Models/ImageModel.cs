using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGalleryApp.Models
{
	public class ImageModel
	{
		public int Id { get; set; }
		public string FileName { get; set; }

		public string Base64 { get; set; }
	}
}