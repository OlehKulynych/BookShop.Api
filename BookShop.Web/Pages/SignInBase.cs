using Blazored.LocalStorage;
using BookShop.Shared.DTO;
using BookShop.Web.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace BookShop.Web.Pages
{
    public class SignInBase : ComponentBase
    {
        [Inject]
        public HttpClient httpClient { get; set; }
        [Inject]
        ILocalStorageService localStorageService { get; set; }

        [Inject]
        AuthenticationStateProvider authenticationStateProvider { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        protected LogInUserDto _logInUserDto = new();
        protected bool _signInSuccessful = false;
        protected bool _attemptToSignInFailed = false;


        protected override async Task OnInitializedAsync()
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/HidePassword.js");
        }
        public async Task HidePassword()
        {
            await _jsModule.InvokeVoidAsync("hidePassword");
        }

        protected async Task SignInUser()
        {
            _attemptToSignInFailed = false;
            var httpResponseMessage = await httpClient.PostAsJsonAsync("/api/User/signIn", _logInUserDto);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string jsonWebToken = await httpResponseMessage.Content.ReadAsStringAsync();
                await localStorageService.SetItemAsync("bearerToken", jsonWebToken);

                await ((ClientAuthenticationStateProvider)authenticationStateProvider).SignIn();
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearerToken", jsonWebToken);


                _signInSuccessful = true;
            }
            else
            {

                _attemptToSignInFailed = true;
            }
        }
    }
}
