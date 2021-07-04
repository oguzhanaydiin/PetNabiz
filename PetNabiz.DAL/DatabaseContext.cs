using System;
using System.Data.Entity;
using PetNabiz.Domain.Models;

namespace PetNabiz.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext():base("PetnabizContext")
        {

        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
    }
}
