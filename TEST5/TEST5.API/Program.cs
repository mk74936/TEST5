using Microsoft.EntityFrameworkCore;
using TEST5.API.Data;
using TEST5.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TEST5DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TEST5"));
});

builder.Services.AddScoped<ICustomerInterface,CustomerRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IProductInterface,ProductRepository>();

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
