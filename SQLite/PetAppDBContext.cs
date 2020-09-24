using AsianDogFood.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SQLite
{
    public class PetAppDBContext : DbContext
    {
        public PetAppDBContext(DbContextOptions<PetAppDBContext> opt) : base(opt)
        {

        }
        
        
       public DbSet<Pet> Pets { get; set; }
       
       public DbSet<Owner> Owners { get; set; }
    }
}