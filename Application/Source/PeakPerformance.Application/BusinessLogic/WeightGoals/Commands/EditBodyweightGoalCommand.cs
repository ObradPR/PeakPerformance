namespace PeakPerformance.Application.BusinessLogic.WeightGoals.Commands;

public class EditBodyweightGoalCommand(WeightGoalDto data) : BaseCommand<Unit>
{
    public WeightGoalDto Data { get; set; } = data;

    public class EditBodyweightGoalCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser) : BaseCommandHandler<EditBodyweightGoalCommand, Unit>(unitOfWork, identityUser)
    {
        public override async Task<Unit> Handle(EditBodyweightGoalCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityUser.Id;
            var data = request.Data;

            var model = await _unitOfWork.WeightGoalRepository.GetSingleAsync(data.Id)
                ?? throw new NotFoundException();

            var weightUnitId = (await _unitOfWork.UserMeasurementPreferenceRepository.GetByUserIdAsync(userId))?.WeightUnitId
               ?? throw new NotFoundException();

            data.ToModel(model, weightUnitId, userId);

            // Save

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}