namespace PeakPerformance.Application.BusinessLogic.WeightGoals.Commands;

public class RemoveBodyweightGoalCommand(long id) : BaseCommand<Unit>
{
    public long Id { get; set; } = id;

    public class RemoveBodyweightGoalCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser) : BaseCommandHandler<RemoveBodyweightGoalCommand, Unit>(unitOfWork, identityUser)
    {
        public override async Task<Unit> Handle(RemoveBodyweightGoalCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.WeightGoalRepository.RemoveAsync(request.Id);

            // Save

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}