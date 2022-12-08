﻿using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("createorder")]
        public async Task CreateOrder(OrderDto orderDto)
        {
            await _orderService.CreateOrderAsync(orderDto);
        }

        [HttpGet]
        [Route("getUserOrder/{name}")]
        public async Task<ActionResult<List<OrderUserDto>>> GetOrderByUser(string name)
        {
            var orders = await _orderService.GetOrderByUser(name);
            if (orders == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orders);
            }

        }
    }
}
