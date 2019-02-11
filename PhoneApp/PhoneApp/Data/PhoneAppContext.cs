using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhoneApp.Models
{
    public class PhoneAppContext : DbContext
    {
        public PhoneAppContext (DbContextOptions<PhoneAppContext> options)
            : base(options)
        {
        }

        public DbSet<PhoneApp.Models.Phone> Phone { get; set; }
    }
}
