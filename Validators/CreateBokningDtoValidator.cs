using Bokningsystem.API.DTOs;
using FluentValidation;
using Bokningsystem.API.DTOs;
using System;

namespace Bokningsystem.API.Validators
{
    public class CreateBokningDtoValidator : AbstractValidator<CreateBokningDto>
    {
        public CreateBokningDtoValidator()
        {
            RuleFor(x => x.AnvandareId).GreaterThan(0);
            RuleFor(x => x.TjanstId).GreaterThan(0);
            RuleFor(x => x.DatumTid).GreaterThan(DateTime.UtcNow.AddMinutes(-1));
        }
    }
}
