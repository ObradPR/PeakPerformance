namespace PeakPerformance.Application.BusinessLogic.Weights.Commands;

public class AddBodyweightCommand(WeightDto data) : BaseCommand<Unit>
{
    public WeightDto Data { get; set; } = data;

    public class AddBodyweightCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser) : BaseCommandHandler<AddBodyweightCommand, Unit>(unitOfWork, identityUser)
    {
        public override async Task<Unit> Handle(AddBodyweightCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityUser.Id;
            var data = request.Data;

            var model = new Weight();
            data.ToModel(model, userId);

            await _unitOfWork.WeightRepository.AddAsync(model);

            // Save

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}