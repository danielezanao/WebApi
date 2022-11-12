using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LeitorContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

//cuidado com isso aqui se der erro foi culpa dele
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


builder.Services.AddScoped<ULeitorRepository, LeitorRepository>();
builder.Services.AddScoped<ILivrosRepository, LivroRepository>();
builder.Services.AddScoped<IEmprestimosRepository, EmprestimosRepository>();

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
//responsavel por forcar a inicializacao do serviço na porta 3000
app.Run("http://localhost:3000");
