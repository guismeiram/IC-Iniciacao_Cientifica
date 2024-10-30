using AutoMapper;
using FluentValidation;
using MediatR;
using SGuF.Application.Common.Interfaces.Repositories;
using SGuF.Application.Common.Models;
using SGuF.Application.Photo.Command.CreatePhoto;
using SGuF.Application.Photo.Queries.GetPhotoList;
using SGuF.Domain.Enities;
using System.Xml.Linq;

namespace SGuF.Application.Photo.Command.CreatePhoto
{
    public class CreatePhotoCommand
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreatePhotoDto? Photo { get; set; }
        }

        /*public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Photo).SetValidator(new CreatePhotoCommandValidator());
            }
        }*/

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IPhotoRepository _photoRepository;
            private readonly IMapper _mapper;

            public Handler(IPhotoRepository photoRepository, IMapper mapper)
            {
                _photoRepository = photoRepository;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var photo = _mapper.Map<SGuF.Domain.Enities.Photo>(request.Photo);

                await _photoRepository.AddAsync(photo);

                var result = await _photoRepository.Complete();

                if (result) return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Failed to create a new Photo");
            }
        }
    }
}
