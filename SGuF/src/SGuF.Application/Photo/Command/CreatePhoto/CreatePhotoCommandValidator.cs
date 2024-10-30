using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGuF.Application.Photo.Command.CreatePhoto;

namespace SGuF.Application.Photo.Command.CreatePhoto
{
    public class CreatePhotoCommandValidator : AbstractValidator<CreatePhotoDto>
    {
        public CreatePhotoCommandValidator() 
        {
            RuleFor(x => x.Author)
                .NotEmpty();

            RuleFor(x => x.ImageUrl)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Author)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty();
        }
    }
}
