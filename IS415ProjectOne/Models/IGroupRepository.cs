using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS415ProjectOne.Models
{
    public interface IGroupRepository
    {
        IQueryable<Group> Groups { get; }

    }
}
