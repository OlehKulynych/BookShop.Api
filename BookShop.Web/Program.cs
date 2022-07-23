using BookShop.Web;
using BookShop.Web.Services;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7236/") });

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IBookCategoryService, BookCategoryService>();
builder.Services.AddScoped<ICartService, CartService>();

await builder.Build().RunAsync();
