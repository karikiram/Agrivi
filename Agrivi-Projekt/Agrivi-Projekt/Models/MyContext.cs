using Agrivi_Projekt.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Agrivi_Projekt.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }

        public DbSet<Brand> Brand { get; set; }
    }
}
