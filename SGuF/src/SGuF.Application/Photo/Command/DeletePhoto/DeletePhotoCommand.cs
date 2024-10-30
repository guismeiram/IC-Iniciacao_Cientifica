using MediatR;
using SGuF.Application.Common.Interfaces.Repositories;
using SGuF.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Application.Photo.Command.DeletePhoto
{
    public class DeletePhotoCommand
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
           
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IPhotoRepository _photo;

            public Handler(IPhotoRepository photo)
            {
                _photo = photo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _photo.DeleteAsync(request.Id);


                if (result) return Result<Unit>.Success(Unit.Value);

                await _photo.Complete();


                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
