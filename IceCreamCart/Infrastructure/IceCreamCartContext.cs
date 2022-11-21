using Microsoft.EntityFrameworkCore;
using IceCreamCart.Models;

namespace IceCreamCart.Infrastructure
{
    public class IceCreamCartContext : DbContext
    {
        public IceCreamCartContext(DbContextOptions<IceCreamCartContext> options)
            : base(options)
        {

        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
    

}
