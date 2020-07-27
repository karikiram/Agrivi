using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrivi_Projekt.Data;
using Agrivi_Projekt.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agrivi_Projekt.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilterController : ControllerBase
	{
		private readonly MyContext _context;
		private readonly IMapper _mapper;

		public FilterController(MyContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet("GetCarsByName")]
		public async Task<ActionResult<IEnumerable<CarDto>>> GetCarsByName()
		{
			var brands = await _context.Brand.ToListAsync();
			var brandsDto = _mapper.Map<List<BrandDto>>(brands);
			var cars = await _context.Car.Include(x => brandsDto).AsQueryable().OrderBy(x => x.CarName).ToListAsync();
			var carsDto = _mapper.Map<List<CarDto>>(cars);
			return carsDto;
		}

		[HttpGet("GetCarsByDate")]
		public async Task<ActionResult<IEnumerable<CarDto>>> GetCarsByDate()
		{
			var brands = await _context.Brand.ToListAsync();
			var brandsDto = _mapper.Map<List<BrandDto>>(brands);
			var cars = await _context.Car.Include(x => brandsDto).AsQueryable().OrderBy(x => x.CarDate).ToListAsync();
			var carsDto = _mapper.Map<List<CarDto>>(cars);
			return carsDto;
		}

		[HttpGet("GetCarsByBrand")]
		public async Task<ActionResult<IEnumerable<CarDto>>> GetCarsByBrand()
		{
			var brands = await _context.Brand.ToListAsync();
			var brandsDto = _mapper.Map<List<BrandDto>>(brands);
			var cars = await _context.Car.Include(x => brandsDto).AsQueryable().OrderBy(x => x.Brand.BrandName).ToListAsync();
			var carsDto = _mapper.Map<List<CarDto>>(cars);
			return carsDto;
		}

		[HttpGet("GetBrandsByName")]
		public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrandDto()
		{
			var brands = await _context.Brand.AsQueryable().OrderBy(x=> x.BrandName).ToListAsync();

			var brandDtos = _mapper.Map<List<BrandDto>>(brands);
			foreach (var brand in brandDtos)
			{
				var cars = _context.Car.Where(x => x.Brand.BrandId == brand.BrandId);
				if (cars != null)
				{
					foreach (var car in cars)
					{
						brand.Car.Add(car);
					}
				}
			}
			return brandDtos;
		}

		[HttpGet("SearchCarsByName/{carName}")]
		public List<CarDto> SearchCarsByName(string carName)
		{
			var brands = _context.Brand.ToList();
			var brandsDto = _mapper.Map<List<BrandDto>>(brands);
			var cars = _context.Car.Include(x => brandsDto).Where(x => x.CarName.ToLower()
			  .Contains(carName.Trim().ToLower())).ToList();
			var carsDto = _mapper.Map<List<CarDto>>(cars);
			return carsDto;
		}

		[HttpGet("SearchBrandsByName/{brandName}")]
		public List<BrandDto> SearchBrandsByName(string brandName)
		{
			var brands = _context.Brand.Where(x => x.BrandName.ToLower()
			  .Contains(brandName.Trim().ToLower())).ToList();
			var brandsDto = _mapper.Map<List<BrandDto>>(brands);
			return brandsDto;
		}
	}
}
