using Agrivi_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrivi_Projekt.Repositories
{
	interface ICarRepository<T> where T : class
	{
		IEnumerable<Car> GetCars();
		Car GetCar(int id);
		void CreateCar(T entity);
		void UpdateCar(T entity);
		void DeleteCar(int id);
	}
}
