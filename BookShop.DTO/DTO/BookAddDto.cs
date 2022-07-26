﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Shared.DTO
{
    public class BookAddDto
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int BookCategoryId { get; set; }
    }
}
