using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagment.Application.Features.LeaveRequest.Requests.Commands;
using HR.LeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Handlers.Commands
{
    internal class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.LeaveRequestDto != null)
            {
                var validator = new UpdateLeaveRequestDtoValidator();
                var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

                if (!validationResult.IsValid)
                    throw new Exception(validationResult.ToString());

                _mapper.Map(request.LeaveRequestDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }

            if (request.ChangeLeaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
            }

            return Unit.Value;
        }
    }
}
