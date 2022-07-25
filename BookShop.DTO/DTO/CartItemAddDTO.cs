using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Shared.Dto
{
    public class CartItemAddDto
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
