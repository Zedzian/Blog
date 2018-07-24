using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
	public class Image
	{
		public int ImageId { get; set; }

		public string Title { get; set; }

		public Byte[] Data { get; set; }
		
		[Display(Name = "Rozmiar obrazka (w bitach)")]
		[DisplayFormat(DataFormatString = "{0:N1}")]
		public long ImageSize { get; set; }

		[Display(Name = "Data wgrania obrazka")]
		[DisplayFormat(DataFormatString = "{0:F}")]
		public DateTime UploadDT { get; set; }

		public string PostId { get; internal set; }

		public Post Post { get; set; }
	}
}