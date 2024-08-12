var builder = WebApplication.CreateBuilder(args);

string CorsConfiguration = "_corsConfiguration";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS
builder.Services.AddCors(options => {
    options.AddPolicy(name: CorsConfiguration,
                      builder => {
                          builder.WithOrigins("http://localhost:4200")
                                 .AllowAnyMethod()  // Permitir cualquier método HTTP (GET, POST, etc.)
                                 .AllowAnyHeader(); // Permitir cualquier cabecera
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CorsConfiguration);  // Aplicar la configuración CORS

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
