using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS415ProjectOne.Models
{
    public class EFGroupRepository : IGroupRepository
    {
        private TempleAppointmentDbContext _context;

        public EFGroupRepository(TempleAppointmentDbContext context)
        {
            _context = context;
        }

        public IQueryable<Group> Groups => (_context.Groups);
    }
}
