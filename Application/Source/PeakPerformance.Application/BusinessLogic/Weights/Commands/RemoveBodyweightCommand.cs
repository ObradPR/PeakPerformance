namespace PeakPerformance.Application.BusinessLogic.Weights.Commands;

public class RemoveBodyweightCommand(long id) : BaseCommand<Unit>
{
    public long Id { get; set; } = id;

    public class RemoveBodyweightCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser) : BaseCommandHandler<RemoveBodyweightCommand, Unit>(unitOfWork, identityUser)
    {
        public override async Task<Unit> Handle(RemoveBodyweightCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.WeightRepository.RemoveAsync(request.Id);

            // Save

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}