namespace BookShop.Api.Models
{
    public class BookCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual List<Book>? Books { get; set; }
    }
}
