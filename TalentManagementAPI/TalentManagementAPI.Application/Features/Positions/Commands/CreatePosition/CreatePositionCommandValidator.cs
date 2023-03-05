using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Interfaces.Repositories;

namespace TalentManagementAPI.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
    {
        private readonly IPositionRepositoryAsync positionRepository;



        /// <summary>
        /// Constructor for CreatePositionCommandValidator class.
        /// </summary>
        /// <param name="positionRepository">IPositionRepositoryAsync object.</param>
        /// <returns>
        /// CreatePositionCommandValidator object.
        /// </returns>
        public CreatePositionCommandValidator(IPositionRepositoryAsync positionRepository)
        {
            this.positionRepository = positionRepository;

            RuleFor(p => p.PositionNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniquePositionNumber).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.PositionTitle)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }



        /// <summary>
        /// Checks if the given position number is unique.
        /// </summary>
        /// <param name="positionNumber">The position number to check.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task<bool> IsUniquePositionNumber(string positionNumber, CancellationToken cancellationToken)
        {
            return await positionRepository.IsUniquePositionNumberAsync(positionNumber);
        }
    }
}