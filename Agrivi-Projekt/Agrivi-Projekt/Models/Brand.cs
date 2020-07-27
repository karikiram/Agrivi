using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Agrivi_Projekt.Models
{
	public class Brand
	{
		[Key]
		public int BrandId { get; set; }
		public string BrandName { get; set; }
		[JsonIgnore]
		public ICollection<Car> Car { get; set; }
	}
}
