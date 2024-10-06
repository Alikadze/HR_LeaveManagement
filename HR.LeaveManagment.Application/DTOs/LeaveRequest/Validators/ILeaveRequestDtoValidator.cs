using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        public ILeaveRequestDtoValidator()
        {
            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be less than End Date.");

            RuleFor(p => p.EndDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be greater than Start Date.");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.RequestComments)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        }
    }
}
