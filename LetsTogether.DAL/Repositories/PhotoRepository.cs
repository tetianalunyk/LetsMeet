using LetsTogether.DAL.EF;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.DAL.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(AppDBContext context) : base(context)
        {
        }
    }
}
