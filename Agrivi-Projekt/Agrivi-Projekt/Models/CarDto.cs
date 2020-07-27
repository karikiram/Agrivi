using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agrivi_Projekt.Models
{
	public class CarDto
	{
		public int CarId { get; set; }
		public string CarName { get; set; }
		public DateTime CarDate { get; set; }
		public string CarDescription { get; set; }
		public int BrandId { get; set; }
		public Brand Brand { get; set; }
	}
}
