using MyServices;
using MyServices.Data;

var builder = WebApplication.CreateBuilder(args);

var productRepository = new InMemoryProductRepository(new List<Product> { { new Product(Guid.NewGuid(), "Coke") { Price = 9.95M } } });
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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();