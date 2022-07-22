using BookShop.Api.Data;
using Microsoft.EntityFrameworkCore;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Api.Repositories;
using BookShop.Api.Repositories.Services;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BookShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
builder.Services.AddScoped<IBookCategoryService, BookCategoryService>();

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors( policy => policy.WithOrigins("http://localhost:7142", "https://localhost:7142")
.AllowAnyMethod()
.WithHeaders(HeaderNames.ContentType)
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
