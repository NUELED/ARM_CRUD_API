using ARM_CRUD_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ARM_CRUD_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
                
        }


        public DbSet<Staff> Staffs { get; set;}
    }
}
