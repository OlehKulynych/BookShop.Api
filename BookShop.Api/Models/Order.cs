namespace BookShop.Api.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string NameClient { get; set; }

        public string SurnameClient { get; set; }

        public string AddressClient { get; set; }

        public string PhoneClient { get; set; }

        public string EmailClient { get; set; }

        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
