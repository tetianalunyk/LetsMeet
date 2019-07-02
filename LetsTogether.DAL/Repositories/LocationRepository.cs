using LetsTogether.DAL.EF;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LetsTogether.DAL.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(AppDBContext context) : base(context)
        {
        }

        public Location FindClone(Location clone)
        {
            return entities.FirstOrDefault(x => x.Country == clone.Country && x.City == clone.City);
        }
    }
}
