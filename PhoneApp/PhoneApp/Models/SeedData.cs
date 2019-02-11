//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PhoneApp.Models
//{
//    public class SeedData
//    {
//    }
//}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PhoneApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PhoneAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PhoneAppContext>>()))
            {
                // Look for any movies.
                if (context.Phone.Any())
                {
                    return;   // DB has been seeded
                }

                context.Phone.AddRange(
                    new Phone
                    {
                        Brand = "OnePlus 6",
                        ReleaseDate = DateTime.Parse("2015-2-12"),
                        Rating = 8.8M,
                        Price = 349.99M
                    },

                    new Phone
                    {
                        Brand = "Google Pixel 2",
                        ReleaseDate = DateTime.Parse("2014-3-13"),
                        Rating = 5.0M,
                        Price = 599.99M
                    },

                    new Phone
                    {
                        Brand = "Samsung Galaxy S9",
                        ReleaseDate = DateTime.Parse("2017-2-23"),
                        Rating = 4.9M,
                        Price = 699.99M
                    },

                    new Phone
                    {
                        Brand = "Apple iPhone XS",
                        ReleaseDate = DateTime.Parse("2017-4-15"),
                        Rating = 4.2M,
                        Price = 899.99M
                    }
                );

                context.SaveChanges();
            }
        }
    }
}