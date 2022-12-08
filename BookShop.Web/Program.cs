using BookShop.Web;
using BookShop.Web.Providers;
using BookShop.Web.Services;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7236/") });


builder.Services.AddScoped<AuthenticationStateProvider, ClientAuthenticationStateProvider>();
builder.Services.AddBlazoredLocalStorage();



//builder.Services.AddScoped<ClientAuthenticationStateProvider>();


builder.Services.AddScoped<IBookService, BookService>();


builder.Services.AddScoped<IBookCategoryService, BookCategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();


await builder.Build().RunAsync();

