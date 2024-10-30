using AutoMapper;
using MediatR;
using SGuF.Application.Common.Mappings;
using SGuF.Application.Photo.Queries.GetPhotoList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Application.Photo.Command.CreatePhoto
{
    public class CreatePhotoDto : IMapFrom<SGuF.Domain.Enities.Photo>
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? ImageUrl { get; set; }
        public string? Type { get; set; }

        /*public void Mapping(Profile profile)
        {
            profile.CreateMap<SGuF.Domain.Enities.Photo, PhotoDto>().ReverseMap();
        }*/
    }
}
