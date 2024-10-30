using SGuF.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Domain.Enities
{
    public class Photo : BaseEntity
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? ImageUrl { get; set; }
        public string? Type { get; set; }

        public IEnumerable<UserLike>? UserLikes { get; set; }

       
    }
}
