using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagment.Application.Exceptions;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagment.Application.Contracts.Persistence;
using HR.LeaveManagment.domain;
using MediatR;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (!validationResult.IsValid)
                throw new Exception();

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

            return leaveAllocation.Id;
        }
    }
}
