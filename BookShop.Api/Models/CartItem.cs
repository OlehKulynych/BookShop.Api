namespace BookShop.Api.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public virtual Book Book { get; set; }
        public virtual Cart Cart { get; set; }

    }
}
