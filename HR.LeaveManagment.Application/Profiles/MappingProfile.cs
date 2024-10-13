using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Queries;
using HR.LeaveManagment.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Persistence.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<ChangeLeaveRequestApprovalDto, UpdateLeaveRequestDto>().ReverseMap();

            CreateMap<CreateLeaveRequestDto, LeaveRequest>()
                //.ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<UpdateLeaveRequestDto, LeaveRequest>()
                //.ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();



            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<CreateLeaveAllocationDto, LeaveAllocation>()
                //.ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<UpdateLeaveAllocationDto, LeaveAllocation>()
                //.ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();




            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<CreateLeaveTypeDto, LeaveType>()
                //.ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ReverseMap();


        }
    }
}
