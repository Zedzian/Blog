using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
	public class File
	{
		[Required]
		[Display(Name = "Nazwa pliku")]
		[StringLength(60, MinimumLength = 3)]
		public string Title { get; set; }

		[Required]
		[Display(Name = "Plik")]
		public IFormFile FormFile { get; set; }
	}
}