﻿using FluentValidation;

namespace MatchDataManager.Api.Models
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(x => x.Name)
                .MaximumLength(255)
                .WithMessage("Length can't be longer than 255 signs.");

            RuleFor(x => x.City)
                .NotNull()
                .NotEmpty()
                .WithMessage("City is required.");

            RuleFor(x => x.City)
                .MaximumLength(55)
                .WithMessage("Length can't be longer than 55 signs.");
        }
    }
}
