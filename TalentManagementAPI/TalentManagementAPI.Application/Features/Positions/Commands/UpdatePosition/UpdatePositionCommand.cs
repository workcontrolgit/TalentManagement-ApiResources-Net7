using MediatR;
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



            /// <summary>
            /// Constructor for UpdatePositionCommandHandler class.
            /// </summary>
            /// <param name="positionRepository">IPositionRepositoryAsync object</param>
            /// <returns>
            /// UpdatePositionCommandHandler object
            /// </returns>
            public UpdatePositionCommandHandler(IPositionRepositoryAsync positionRepository)
            {
                _positionRepository = positionRepository;
            }



            /// <summary>
            /// Handles the UpdatePositionCommand and updates the position in the repository.
            /// </summary>
            /// <param name="command">The command containing the updated position information.</param>
            /// <param name="cancellationToken">The cancellation token.</param>
            /// <returns>A response containing the Id of the updated position.</returns>
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