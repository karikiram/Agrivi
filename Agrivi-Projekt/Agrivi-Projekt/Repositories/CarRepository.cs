using Agrivi_Projekt.Data;
using Agrivi_Projekt.Models;
using Microsoft.EntityFrameworkCore;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrivi_Projekt.Repositories
{
	public class CarRepository<T> : ICarRepository<T> where T : class
	{
		private readonly MyContext _context;

		public CarRepository(MyContext context)
			=> _context = context;
		public void CreateCar(T entity)
			=> _context.Set<T>().Add(entity); 

		public void DeleteCar(int id)
		{
			var car = _context.Set<T>().Find(id);

			_context.Remove(car);
		}

		public Car GetCar(int id)
			=> _context.Set<Car>().Find(id);

		public IEnumerable<Car> GetCars()
			=> _context.Set<Car>().ToList();

		public void UpdateCar(T entity)
			=> _context.Set<T>().Attach(entity);
	}
}
