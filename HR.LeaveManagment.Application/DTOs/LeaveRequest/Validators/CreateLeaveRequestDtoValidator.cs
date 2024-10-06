using FluentValidation;
using HR.LeaveManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {

        public CreateLeaveRequestDtoValidator()
        {
            Include(new ILeaveRequestDtoValidator());

        }
    }
}