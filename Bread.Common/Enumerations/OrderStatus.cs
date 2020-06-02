namespace Bread.Common.Enumerations
{
    public enum OrderStatus
    {
        Placed = 1,
        PaymentAccepted,
        PaymentDeclined,
        RestaurantAccepted,
        RestaurantDeclined,
        Processing,
        Delivering,
        CustomerAccepted,
        CustomerDeclined
    }
}
