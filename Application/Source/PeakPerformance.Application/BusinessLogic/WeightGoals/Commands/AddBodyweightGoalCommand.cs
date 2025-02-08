namespace PeakPerformance.Application.BusinessLogic.WeightGoals.Commands;

public class AddBodyweightGoalCommand(WeightGoalDto data) : BaseCommand<Unit>
{
    public WeightGoalDto Data { get; set; } = data;

    public class AddBodyweightGoalCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser) : BaseCommandHandler<AddBodyweightGoalCommand, Unit>(unitOfWork, identityUser)
    {
        public override async Task<Unit> Handle(AddBodyweightGoalCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityUser.Id;
            var data = request.Data;

            var weightUnitId = (await _unitOfWork.UserMeasurementPreferenceRepository.GetByUserIdAsync(userId))?.WeightUnitId
                ?? throw new NotFoundException();

            var model = new WeightGoal();
            data.ToModel(model, weightUnitId, userId);

            await _unitOfWork.WeightGoalRepository.AddAsync(model);

            // Save

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}