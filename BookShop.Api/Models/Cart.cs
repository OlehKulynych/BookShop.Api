namespace BookShop.Api.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public string? UserId { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
    }
}
