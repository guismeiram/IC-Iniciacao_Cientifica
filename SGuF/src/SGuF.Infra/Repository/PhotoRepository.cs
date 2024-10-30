using SGuF.Application.Common.Interfaces.Repositories;
using SGuF.Domain.Enities;
using SGuF.Infra.Context;
using SGuF.Infra.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Infra.Repository
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(SGuFDbContext context) : base(context)
        {
        }
    }
}
