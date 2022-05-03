using Devfreela.Core.DTOs;
using Devfreela.Core.Services;

namespace Devfreela.Infrastructure.Services
{

    public class PaymentService : IPaymentService
    {
        private readonly IMessageBusService _messageBusService;

        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            _messageBusService.Publish("Payments", paymentInfoDTO.ToBytes());
        }
    }
}
