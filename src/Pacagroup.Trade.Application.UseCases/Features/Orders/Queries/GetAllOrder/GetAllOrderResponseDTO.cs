namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetAllOrder
{
    public class GetAllOrderResponseDTO
    {
        public int Id { get; set; }
        public required string Symbol { get; set; }
        public OrderSide Side { get; set; }
        public DateTime TransactTime { get; set; }
        public int Quanty { get; set; }
        public OrderType Type { get; set; }
        public decimal Price { get; set; }
        public required string Currency { get; set; }
        public string? Text { get; set; }
    }

    public enum OrderSide
    {
        BUY = 0,
        SELL = 1,
    }

    public enum OrderType
    {
        LIMIT = 0,
        MARKET = 1,
    }
}
