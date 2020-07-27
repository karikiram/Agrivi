using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agrivi_Projekt.Data;
using Agrivi_Projekt.Models;
using AutoMapper;
using Agrivi_Projekt.Repositories;

namespace Agrivi_Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyContext _context;

        public BrandsController(MyContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrandDto()
        {
            var brands = await _context.Brand.AsQueryable().OrderBy(x => x.BrandName).ToListAsync();
            
            var brandDtos = _mapper.Map<List<BrandDto>>(brands);
            foreach(var brand in brandDtos)
			{
                var cars =  _context.Car.Where(x => x.Brand.BrandId == brand.BrandId);
                if(cars != null)
				{
                    foreach (var car in cars)
					{
                        brand.Car.Add(car);
                    }
				}
			}
            return brandDtos;
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> GetBrandDto(int id)
        {
            var brand = await _context.Brand.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }
            else
			{
                var brandDto = _mapper.Map<BrandDto>(brand);
                var cars = _context.Car.Where(x=>x.Brand.BrandId == brandDto.BrandId);
                foreach(var car in cars)
				{
                    brandDto.Car.Add(car);
				}
                return brandDto;
			}

        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrandDto(int id, BrandDto brandDto)
        {
            if (id != brandDto.BrandId)
            {
                return BadRequest();
            }
            var brand = _context.Brand.FirstOrDefault(x => x.BrandId == brandDto.BrandId);
            brand.BrandName = brandDto.BrandName;
            _context.Entry(brand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandDtoExists(id))
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

        // POST: api/Brands
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BrandDto>> PostBrandDto(BrandDto brandDto)
        {
            var brand = new Brand
            {
                BrandName = brandDto.BrandName
            };
            _context.Brand.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrandDto", new { id = brandDto.BrandId }, brandDto);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BrandDto>> DeleteBrandDto(int id)
        {
            var brand = await _context.Brand.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.Brand.Remove(brand);
            await _context.SaveChangesAsync();

            return new BrandDto();
        }

        private bool BrandDtoExists(int id)
        {
            return _context.Brand.Any(e => e.BrandId == id);
        }
    }
}
