using AutoMapper;
using TalentManagementAPI.Application.Features.Employees.Queries.GetEmployees;
using TalentManagementAPI.Application.Features.Positions.Commands.CreatePosition;
using TalentManagementAPI.Application.Features.Positions.Queries.GetPositions;
using TalentManagementAPI.Domain.Entities;

namespace TalentManagementAPI.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Position, GetPositionsViewModel>().ReverseMap();
            CreateMap<Employee, GetEmployeesViewModel>().ReverseMap();
            CreateMap<CreatePositionCommand, Position>();
        }
    }
}