using MediatR;

namespace Devfreela.Aplication.Commands.FinishProject
{
    public class FinishProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }
    }
}
