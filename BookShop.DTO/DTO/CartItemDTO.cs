﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DTO.DTO
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CartId { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}