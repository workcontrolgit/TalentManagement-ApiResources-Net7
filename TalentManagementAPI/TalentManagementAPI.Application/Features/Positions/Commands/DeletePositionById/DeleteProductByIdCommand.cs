using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Exceptions;
using TalentManagementAPI.Application.Interfaces.Repositories;
using TalentManagementAPI.Application.Wrappers;

namespace TalentManagementAPI.Application.Features.Positions.Commands.DeletePositionById
{
    public class DeletePositionByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }

        public class DeletePositionByIdCommandHandler : IRequestHandler<DeletePositionByIdCommand, Response<Guid>>
        {
            private readonly IPositionRepositoryAsync _positionRepository;



            /// <summary>
            /// Constructor for DeletePositionByIdCommandHandler class.
            /// </summary>
            /// <param name="positionRepository">IPositionRepositoryAsync object</param>
            /// <returns>
            /// DeletePositionByIdCommandHandler object
            /// </returns>
            public DeletePositionByIdCommandHandler(IPositionRepositoryAsync positionRepository)
            {
                _positionRepository = positionRepository;
            }



            /// <summary>
            /// Handles the DeletePositionByIdCommand and deletes the position with the given Id.
            /// </summary>
            /// <param name="command">The DeletePositionByIdCommand containing the Id of the position to delete.</param>
            /// <param name="cancellationToken">The cancellation token.</param>
            /// <returns>A Response containing the Id of the deleted position.</returns>
            public async Task<Response<Guid>> Handle(DeletePositionByIdCommand command, CancellationToken cancellationToken)
            {
                var position = await _positionRepository.GetByIdAsync(command.Id);
                if (position == null) throw new ApiException($"Position Not Found.");
                await _positionRepository.DeleteAsync(position);
                return new Response<Guid>(position.Id);
            }
        }
    }
}