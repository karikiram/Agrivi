using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agrivi_Projekt.Models
{
	public class Car
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CarId { get; set; }
		[Required(AllowEmptyStrings = false)]
		public string CarName { get; set; }
		[Required(AllowEmptyStrings = false)]
		[DataType(DataType.Date)]
		public DateTime CarDate { get; set; }
		public string CarDescription { get; set; }
		public int BrandId { get; set; }
		public Brand Brand { get; set; }

	}

}
