using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agrivi_Projekt.Models
{
	public class BrandDto
	{
		public int BrandId { get; set; }
		public string BrandName { get; set; }
		[JsonIgnore]
		public ICollection<Car> Car { get; set; }
	}
}
