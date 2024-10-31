using Microsoft.EntityFrameworkCore;
using fisio_ltd_back.Models;

var builder = WebApplication.CreateBuilder(args);

//#region DbContext
// Configuração do DbContext para usar PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
);
//#endregion

// Adiciona serviços ao contêiner.
builder.Services.AddEndpointsApiExplorer(); // Para explorar endpoints da API
builder.Services.AddSwaggerGen(); // Para gerar documentação Swagger
builder.Services.AddControllers(); // Adiciona suporte ao controlador

// Configuração de CORS para permitir chamadas do frontend Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
        builder.WithOrigins("http://localhost:4200") // Permitir a origem da aplicação Angular
               .AllowAnyMethod() // Permitir qualquer método (GET, POST, etc.)
               .AllowAnyHeader()); // Permitir qualquer cabeçalho
});

var app = builder.Build();

// Configuração do pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger apenas em ambiente de desenvolvimento
    app.UseSwaggerUI(); // Interface do Swagger
}

app.UseCors("AllowSpecificOrigin"); // Aplicar a política CORS

app.MapControllers(); // Mapeia os controladores da API
app.Run(); // Inicia a aplicação
