using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IS415ProjectOne.Models
{
    public class TempleAppointmentDbContext : DbContext
    {
        public TempleAppointmentDbContext(DbContextOptions<TempleAppointmentDbContext> options) : base(options)
        {

        }
        public DbSet<Group> Groups { get; set; }

    }
}
