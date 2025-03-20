using BookStoreApi.Models;
using BookStoreApi.Services;

var builder = WebApplication.CreateBuilder(args);
//
// Add services to the container.
//

// BookStoreDatabaseSettings class is used to store the BookStoreDatabase property values from appsettings.json.
// The JSON and C# property names are named identically to ease the mapping process.
builder.Services.Configure<BookStoreDatabaseSettings>(builder.Configuration.GetSection("BookStoreDatabase"));

//MongoClient should be registered in DI with a singleton service lifetime!
builder.Services.AddSingleton<BooksService>(); 

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
//
// Configure the HTTP request pipeline.
//
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
