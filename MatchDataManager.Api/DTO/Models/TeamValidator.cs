using FluentValidation;

namespace MatchDataManager.Api.Models
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(x => x.Name)
                .MaximumLength(255)
                .WithMessage("Length can't be longer than 255 signs.");

            RuleFor(x => x.CoachName)
                .NotEmpty()
                .WithMessage("CoachName is required.");

            RuleFor(x => x.CoachName)
                .MaximumLength(55)
                .WithMessage("Length can't be longer than 55 signs.");
        }
    }
}
