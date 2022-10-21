using BookShop.Shared.DTO;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BookShop.Web.Pages
{
    public class RegisterBase: ComponentBase
    {
        [Inject]
        public HttpClient httpClient { get; set; }

        protected RegisterUserDto _registerUserDto = new() { EmailAddress = "user@example.com", Password = "Qwe123!", Name = "admin", Surname = "admin" };
        protected bool _registerSuccessful = false;
        protected bool _attemptToRegisterFailed = false;
        protected string? _attemptToRegisterFailedErrorMessage = null;

        protected async Task RegisterUser()
        {
            _attemptToRegisterFailed = false;
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync("/api/User/Register", _registerUserDto);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                _registerSuccessful = true;
            }
            else
            {
                string serverErrorMessages = await httpResponseMessage.Content.ReadAsStringAsync();

                _attemptToRegisterFailedErrorMessage = $"{serverErrorMessages} Try Again...";

                _attemptToRegisterFailed = true;
            }
        }
    }
}
