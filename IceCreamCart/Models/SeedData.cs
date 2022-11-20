using IceCreamCart.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Threading.Tasks;
using IceCreamCart.Models;

namespace IceCreamCart.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider )

        {
            using (var context = new IceCreamCartContext(serviceProvider.GetRequiredService<DbContextOptions<IceCreamCartContext>>()))
            {
                
                    if (context == null || context.Pages == null)
                    {
                        throw new ArgumentNullException("Null IceCreamCartContext");
                    }

                    if (context.Pages.Any())
                {
                    return;
                }
                context.Pages.AddRange(new Page
                {
                    Title = "Home",
                    Slug = "home",
                    Context = "home page",
                    Sorting = 0
                }, new Page
                {
                    Title = "About Us",
                    Slug = "about-us",
                    Context = "about us page",
                    Sorting = 100
                }, new Page
                {
                    Title = "Services",
                    Slug = "services",
                    Context = "services page",
                    Sorting = 100
                }, new Page
                {
                    Title = "Contact Us",
                    Slug = "contact-us",
                    Context = "contact us page",
                    Sorting = 100
                }
                );

                context.SaveChanges();
            }
        }
    }
}
