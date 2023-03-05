using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Interfaces.Repositories;
using TalentManagementAPI.Application.Wrappers;

namespace TalentManagementAPI.Application.Features.Positions.Commands.CreatePosition
{
    public partial class InsertMockPositionCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }

    public class SeedPositionCommandHandler : IRequestHandler<InsertMockPositionCommand, Response<int>>
    {
        private readonly IPositionRepositoryAsync _positionRepository;



        /// <summary>
        /// Constructor for the SeedPositionCommandHandler class.
        /// </summary>
        /// <param name="positionRepository">The IPositionRepositoryAsync object to be used.</param>
        /// <returns>
        /// A new instance of the SeedPositionCommandHandler class.
        /// </returns>
        public SeedPositionCommandHandler(IPositionRepositoryAsync positionRepository)
        {
            _positionRepository = positionRepository;
        }



        /// <summary>
        /// Handles the InsertMockPositionCommand by seeding the data in the PositionRepository and returning a Response.
        /// </summary>
        /// <param name="request">The InsertMockPositionCommand to be handled.</param>
        /// <param name="cancellationToken">The CancellationToken used for cancellation.</param>
        /// <returns>A Response containing the number of rows inserted.</returns>
        public async Task<Response<int>> Handle(InsertMockPositionCommand request, CancellationToken cancellationToken)
        {
            await _positionRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}