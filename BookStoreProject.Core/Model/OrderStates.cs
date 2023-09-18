namespace BookStoreProject.Model
{
    public enum OrderState : byte
    {
        NextUp,
        Processing,
        Shipping,
        Delivered,
        Canceled
    }
}