using FluentValidation;
using MinimalAPI_2.Models;

namespace MinimalAPI_2.Validation
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(x => x.Synopsis).NotEmpty().MinimumLength(10);
        }
    }
}
