namespace BookShop.Api.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        public int BookId { get; set; }
        public uint Price { get; set; }

        public virtual Book Book { get; set; }
        public virtual Order order { get; set; }
    }
}
