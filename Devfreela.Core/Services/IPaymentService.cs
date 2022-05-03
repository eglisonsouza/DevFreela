using Devfreela.Core.DTOs;

namespace Devfreela.Core.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
