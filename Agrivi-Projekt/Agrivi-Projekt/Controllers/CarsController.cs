using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Agrivi_Projekt.Data;
using Agrivi_Projekt.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Agrivi_Projekt.Repositories;

namespace Agrivi_Projekt.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly MyContext _context;
		private readonly IMapper _mapper;

		public CarsController(MyContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/Cars
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CarDto>>> GetCarDto()
		{
			var brands = await _context.Brand.ToListAsync();
			var brandsDto = _mapper.Map<List<BrandDto>>(brands);
			var cars = await _context.Car.Include(x=>brandsDto).ToListAsync();
			var carsDto = _mapper.Map<List<CarDto>>(cars);
			return carsDto;
		}

		// GET: api/Cars/5
		[HttpGet("{id}")]
		public async Task<ActionResult<CarDto>> GetCarDto(int id)
		{
			var brand = await _context.Brand.ToListAsync();
			var brandDto = _mapper.Map<List<BrandDto>>(brand);
			var car = await _context.Car.Include(x => brand).SingleOrDefaultAsync(x => x.CarId == id);

			if (car == null)
			{
				return NotFound();
			}
			else
			{
				var carDto = _mapper.Map<CarDto>(car);

				return carDto;
			}

		}

		// PUT: api/Cars/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCarDto(int id, CarDto carDto)
		{
			if (id != carDto.CarId)
			{
				return BadRequest();
			}

			var car = _context.Car.FirstOrDefault(x => x.CarId == id);
			car.CarName = carDto.CarName;
			car.CarDescription = carDto.CarDescription;
			car.CarDate = carDto.CarDate;
			car.BrandId = carDto.BrandId;
			_context.Entry(car).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CarDtoExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Cars
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<CarDto>> PostCarDto(CarDto carDto)
		{
			var car = new Car
			{
				CarName = carDto.CarName,
				CarDescription = carDto.CarDescription,
				CarDate = carDto.CarDate,
				BrandId = carDto.BrandId
			};

			_context.Car.Add(car);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetCarDto", new { id = carDto.CarId }, carDto);
		}

		// DELETE: api/Cars/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<CarDto>> DeleteCarDto(int id)
		{
			var carDto = await _context.Car.FindAsync(id);
			if (carDto == null)
			{
				return NotFound();
			}

			_context.Car.Remove(carDto);
			await _context.SaveChangesAsync();

			return new CarDto();
		}

		private bool CarDtoExists(int id)
		{
			return _context.Car.Any(e => e.CarId == id);
		}
	}
}
