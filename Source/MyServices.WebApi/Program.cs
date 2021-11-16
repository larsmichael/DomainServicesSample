using MyServices;
using MyServices.Data;
using MyServices.WebApi;

var builder = WebApplication.CreateBuilder(args);

var products = new List<Product> { 
    new Product(Guid.NewGuid(), "Coke") { Price = 9.95M },
    new Product(Guid.NewGuid(), "Fanta") { Price = 8.95M }
};
var productRepository = new InMemoryProductRepository(products);
builder.Services.AddScoped<IProductRepository>(_ => productRepository);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandling();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
