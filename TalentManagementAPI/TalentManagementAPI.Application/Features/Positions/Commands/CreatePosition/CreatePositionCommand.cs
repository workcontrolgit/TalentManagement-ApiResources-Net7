using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Interfaces.Repositories;
using TalentManagementAPI.Application.Wrappers;
using TalentManagementAPI.Domain.Entities;

namespace TalentManagementAPI.Application.Features.Positions.Commands.CreatePosition
{
    public partial class CreatePositionCommand : IRequest<Response<Guid>>
    {
        public string PositionTitle { get; set; }
        public string PositionNumber { get; set; }
        public string PositionDescription { get; set; }
        public decimal PositionSalary { get; set; }
    }

    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, Response<Guid>>
    {
        private readonly IPositionRepositoryAsync _positionRepository;
        private readonly IMapper _mapper;



        /// <summary>
        /// Constructor for CreatePositionCommandHandler class.
        /// </summary>
        /// <param name="positionRepository">IPositionRepositoryAsync object</param>
        /// <param name="mapper">IMapper object</param>
        /// <returns>
        /// CreatePositionCommandHandler object
        /// </returns>
        public CreatePositionCommandHandler(IPositionRepositoryAsync positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }



        /// <summary>
        /// Handles the CreatePositionCommand request by mapping it to a position object and adding it to the position repository.
        /// </summary>
        /// <param name="request">The CreatePositionCommand request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A response containing the Id of the created position.</returns>
        public async Task<Response<Guid>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = _mapper.Map<Position>(request);
            await _positionRepository.AddAsync(position);
            return new Response<Guid>(position.Id);
        }
    }
}