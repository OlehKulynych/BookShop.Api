using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Shared.DTO
{
    public class OrderDto
    {
        public string NameClient { get; set; }

        public string SurnameClient { get; set; }

        public string AddressClient { get; set; }

        public string PhoneClient { get; set; }

        public string EmailClient { get; set; }

        public List<OrderDetailDto>? orderDetailDtos { get; set; }
    }
}
