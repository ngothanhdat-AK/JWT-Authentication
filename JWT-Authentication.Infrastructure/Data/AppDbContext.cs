using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWT_Authentication.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWT_Authentication.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
