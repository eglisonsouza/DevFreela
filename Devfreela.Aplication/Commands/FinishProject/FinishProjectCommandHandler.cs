using Devfreela.Core.DTOs;
using Devfreela.Core.Repositories;
using Devfreela.Core.Services;
using MediatR;

namespace Devfreela.Aplication.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IPaymentService _paymentService;

        public FinishProjectCommandHandler(IProjectRepository projectRepository, IPaymentService paymentService)
        {
            _projectRepository = projectRepository;
            _paymentService = paymentService;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            var paymentInfoDto = new PaymentInfoDTO(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, project.TotalCost);

            _paymentService.ProcessPayment(paymentInfoDto);

            project.SetPaymentPending();

            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
