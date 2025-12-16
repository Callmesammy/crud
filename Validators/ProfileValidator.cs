
using Crud.Dto;
using FluentValidation;

namespace Crud.Validators; 


public class ProfileValidator : AbstractValidator<ProfileDto>
{
    public  ProfileValidator()
    {
        RuleFor(x => x.FullName)
        .NotEmpty().WithMessage("Enter full name please")
        .MaximumLength(100).WithMessage("FullName must not exceed 100 characters");


        RuleFor(x => x.Email)
        .NotEmpty().WithMessage("Enter Email address")
        .MaximumLength(200).WithMessage("Email must not exceed 200 character");
    }
}