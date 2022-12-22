namespace BethanyPieShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
