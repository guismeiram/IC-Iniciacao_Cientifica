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
    public class GetPhoto
    {

        public class Query : IRequest<Result<PhotoDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PhotoDto>>
        {
            private readonly IPhotoRepository _photoRepository;
            private readonly IMapper _mapper;

            public Handler(IPhotoRepository photoRepository, IMapper mapper)
            {
                _photoRepository = photoRepository;
                _mapper = mapper;
            }

            public async Task<Result<PhotoDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _photoRepository.Get(request.Id);

                var photo = _mapper.Map<PhotoDto>(result);

                return Result<PhotoDto>.Success(photo);
            }
        }
    }
}
