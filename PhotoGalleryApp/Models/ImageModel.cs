using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGalleryApp.Models
{
	public class ImageModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		public string FileName { get; set; }

		public string Base64 { get; set; }

		[JsonProperty("top")]
		public string Top { get; set; }

		[JsonProperty("left")]
		public string Left { get; set; }
	}
}