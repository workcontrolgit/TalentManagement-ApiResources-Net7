﻿using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Exceptions;
using TalentManagementAPI.Application.Interfaces.Repositories;
using TalentManagementAPI.Application.Wrappers;

namespace TalentManagementAPI.Application.Features.Positions.Commands.UpdatePosition
{
    public class UpdatePositionCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string PositionTitle { get; set; }
        public string PositionDescription { get; set; }
        public decimal PositionSalary { get; set; }

        public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, Response<Guid>>
        {
            private readonly IPositionRepositoryAsync _positionRepository;

            public UpdatePositionCommandHandler(IPositionRepositoryAsync positionRepository)
            {
                _positionRepository = positionRepository;
            }

            public async Task<Response<Guid>> Handle(UpdatePositionCommand command, CancellationToken cancellationToken)
            {
                var position = await _positionRepository.GetByIdAsync(command.Id);

                if (position == null)
                {
                    throw new ApiException($"Position Not Found.");
                }
                else
                {
                    position.PositionTitle = command.PositionTitle;
                    position.PositionSalary = command.PositionSalary;
                    position.PositionDescription = command.PositionDescription;
                    await _positionRepository.UpdateAsync(position);
                    return new Response<Guid>(position.Id);
                }
            }
        }
    }
}