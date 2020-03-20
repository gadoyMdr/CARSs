using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CARS.Models;
using Microsoft.EntityFrameworkCore;

namespace CARS.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CARS.Models.Vehicule> Vehicule { get; set; }
        public DbSet<CARS.Models.Step> Step { get; set; }
        public DbSet<CARS.Models.TechnicalControl> TechnicalControl { get; set; }
        public DbSet<CARS.Models.VehiculeType> VehiculeType { get; set; }
        public DbSet<CARS.Models.Category> Category { get; set; }
        public DbSet<CARS.Models.Brand> Brand { get; set; }
        public DbSet<CARS.Models.Model> CarModel { get; set; }
    }
}
