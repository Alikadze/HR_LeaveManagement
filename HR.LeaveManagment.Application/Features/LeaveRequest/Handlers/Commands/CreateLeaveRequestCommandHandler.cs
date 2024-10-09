using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagment.Application.Features.LeaveRequest.Requests.Commands;
using HR.LeaveManagment.Application.Contracts.Persistence;
using HR.LeaveManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagment.Application.Contracts.Infrastructure;
using HR.LeaveManagment.Application.Models;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Handlers.Commands
{
    internal class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _emailSender = emailSender;

        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (!validationResult.IsValid)
            {
                responce.Succeeded = false;
                responce.Message = validationResult.ToString();
                responce.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<domain.LeaveRequest>(request.LeaveRequestDto);

            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            responce.Succeeded = true;
            responce.Message = "Leave Request Added Successfully";
            responce.Id = leaveRequest.Id;

            var email = new Email
            {
                To = "admin@localhost",
                Body = $"Leave Request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D} has been submitted successfully.",
                Subject = "Leave Request Submitted",
            };
            try
            {
                await _emailSender.SendEmail(email);

            }
            catch (Exception ex)
            {
                responce.Succeeded = false;
                responce.Message = "Leave Request Added Successfully, but the email notification failed.";
            }

            return responce;
        }
    }
}
