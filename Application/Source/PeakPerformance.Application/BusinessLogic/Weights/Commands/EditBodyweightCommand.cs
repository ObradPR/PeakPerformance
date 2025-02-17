namespace PeakPerformance.Application.BusinessLogic.Weights.Commands;

public class EditBodyweightCommand(WeightDto data) : BaseCommand<Unit>
{
    public WeightDto Data { get; set; } = data;

    public class EditBodyweightCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser) : BaseCommandHandler<EditBodyweightCommand, Unit>(unitOfWork, identityUser)
    {
        public override async Task<Unit> Handle(EditBodyweightCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityUser.Id;
            var data = request.Data;

            var model = await _unitOfWork.WeightRepository.GetSingleAsync(data.Id)
                ?? throw new NotFoundException();

            data.ToModel(model, userId);

            // Save

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}