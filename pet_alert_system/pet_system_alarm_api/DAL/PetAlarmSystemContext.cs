using Microsoft.EntityFrameworkCore;
using pet_system_alarm_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pet_system_alarm_api.DAL
{
    public class PetAlarmSystemContext : DbContext
    {
        public PetAlarmSystemContext(DbContextOptions<PetAlarmSystemContext> options) : base(options)
        {

        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PetLocation> PetLocations { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().ToTable("Pet");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<PetLocation>().ToTable("PetLocation");
            modelBuilder.Entity<Hospital>().ToTable("Hospital");
            modelBuilder.Entity<Vaccine>().ToTable("Vaccine");
        }
    }
}
