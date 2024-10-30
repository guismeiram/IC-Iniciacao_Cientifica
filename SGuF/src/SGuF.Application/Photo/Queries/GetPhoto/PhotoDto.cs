using AutoMapper;
using MediatR;
using SGuF.Application.Common.Interfaces.Repositories;
using SGuF.Application.Common.Mappings;
using SGuF.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Application.Photo.Queries.GetPhoto
{
    public class PhotoDto : IMapFrom<SGuF.Domain.Enities.Photo>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }

        
    }
}
