using EindomsHavnAPI.Data.Context;
using EindomsHavnAPI.Repositories.AboutRepository;
using EindomsHavnAPI.Repositories.CategoryRepository;
using EindomsHavnAPI.Repositories.ContactRepository;
using EindomsHavnAPI.Repositories.EmployeeRepository;
using EindomsHavnAPI.Repositories.NewsletterRepository;
using EindomsHavnAPI.Repositories.ProductRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<INewsletterRepository, NewsletterRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IProductDetailsRepository, ProductDetailsRepository>();
builder.Services.AddTransient<IAboutRepository, AboutRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();