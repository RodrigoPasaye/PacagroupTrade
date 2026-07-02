using Pacagroup.Trade.Domain.Commons;

namespace Pacagroup.Trade.Domain.Events
{
    public class OrderCanceledEvent : BaseEvent
    {
        public int Id { get; set; }
    }
}
