using AutoMapper;
using SGuF.Application.Common.Mappings;
using SGuF.Application.Photo.Command.CreatePhoto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Application.Photo.Queries.GetPhotoList
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhotoDto, SGuF.Domain.Enities.Photo>()
                .ReverseMap();
        }
    }
}
