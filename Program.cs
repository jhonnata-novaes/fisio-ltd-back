using Microsoft.EntityFrameworkCore;
using fisio_ltd_back.Models;

var builder = WebApplication.CreateBuilder(args);

#region DbContext
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
);
#endregion

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Adicione a configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200") // Permitir a origem da sua aplicação Angular
                          .AllowAnyMethod() // Permitir qualquer método (GET, POST, etc.)
                          .AllowAnyHeader()); // Permitir qualquer cabeçalho
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.MapControllers();
app.Run();
