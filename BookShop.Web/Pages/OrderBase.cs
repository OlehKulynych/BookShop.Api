using BookShop.Shared.DTO;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BookShop.Web.Pages
{
    public class OrderBase: ComponentBase
    {
        [Inject]
        public IUserService userService { get; set; }

        [Inject]
        public IOrderService orderService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        public IEnumerable<CartItemDto> cartItems { get; set; }
        public UserDto userDto = new UserDto();
        public OrderDto orderDto = new OrderDto();
        public string ErrorMessage { get; set; }

        [Inject]
        AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }

        protected async override Task OnInitializedAsync()
        {
           
            try
            {
                var state = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
                var user = state.User;
                if (user.Identity.IsAuthenticated)
                {
                    userDto = await userService.GetCurrentUser(user.Identity.Name);
                    orderDto.NameClient = userDto.Name;
                    orderDto.SurnameClient = userDto.Surname;
                    orderDto.EmailClient = userDto.EmailAddress;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task CreateOrderAsync()
        {
            try
            {
                if(orderDto != null)
                {
                    await orderService.CreateOrderAsync(orderDto);
                    navigationManager.NavigateTo("/");
                }
                
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
