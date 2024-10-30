using SGuF.Domain.Common.Models;
using SGuF.Domain.Enities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Domain.Enities
{
    public class UserLike : BaseEntity
    {
        public AppUser User { get; set; }
        public string UserId { get; set; }

        public Guid PhotoId { get; set; }
        public Photo Photo { get; set; }

    }
}
