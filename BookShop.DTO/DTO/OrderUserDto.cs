using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Shared.DTO
{
    public class OrderUserDto
    {
        public string bookName { get; set; }

        public string quantity { get; set; }

        public uint price { get; set; }

        public DateTime OrderTime { get; set; }

    }
}
