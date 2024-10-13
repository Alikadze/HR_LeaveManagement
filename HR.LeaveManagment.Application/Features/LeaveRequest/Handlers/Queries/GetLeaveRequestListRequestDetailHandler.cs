using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.Features.LeaveRequest.Requests.Queries;
using HR.LeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.domain;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Handlers.Queries
{
    internal class GetLeaveRequestListRequestDetailHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListRequestDetailHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}
