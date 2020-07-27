using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrivi_Projekt.Models;
using AutoMapper;

namespace Agrivi_Projekt.Extensions
{
	public class AutoMapping : Profile
	{
		public AutoMapping()
		{
			CreateMap<Car, CarDto>();
			CreateMap<Brand, BrandDto>();
		}
	}
}
