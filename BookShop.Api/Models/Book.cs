namespace BookShop.Api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int BookCategoryId { get; set; }
        public bool isDeleted { get; set; }
        public virtual BookCategory BookCategory { get; set; }
       
    }
}
