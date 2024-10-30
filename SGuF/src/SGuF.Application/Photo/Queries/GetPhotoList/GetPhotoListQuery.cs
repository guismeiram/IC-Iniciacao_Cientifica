using AutoMapper;
using MediatR;
using SGuF.Application.Common.Interfaces.Repositories;
using SGuF.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Application.Photo.Queries.GetPhotoList
{
    public class GetPhotoListQuery
    {
        public class Query : IRequest<Result<IEnumerable<PhotoDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<IEnumerable<PhotoDto>>>
        {
            private readonly IPhotoRepository _photoRepository;
            private readonly IMapper _mapper;

            public Handler(IPhotoRepository photoRepository, IMapper mapper)
            {
                _photoRepository = photoRepository;
                _mapper = mapper;
            }

            public async Task<Result<IEnumerable<PhotoDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var photo = await _photoRepository.GetAll();

                return Result<IEnumerable<PhotoDto>>.Success(_mapper.Map<IEnumerable<PhotoDto>>(photo));
            }
        }
    }
}

