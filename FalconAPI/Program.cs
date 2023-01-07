using FalconDomain.Interfaces;
using FalconRepository.Data;
using FalconRepository.Repository;
using FalconServices.Services;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ILog log = LogManager.GetLogger(typeof(Program));

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");


var db = builder.Services.AddDbContextPool<DBContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

log.Info("Log iniciado");
builder.Services.AddSingleton(typeof(ILog), log);

log.Info("Serviços iniciados");
builder.Services.AddScoped<IRepositoryProduto, ProdutoRepository>();
builder.Services.AddScoped<IRepositoryVenda, VendaRepository>();
builder.Services.AddScoped<IRepositoryVendedor, VendedorRepository>();
builder.Services.AddScoped<IServiceProduto, ProdutoService>();
builder.Services.AddScoped<IServiceVenda, VendaService>();
builder.Services.AddScoped<IServiceVendedor, VendedorService>();

log.Info("Adicionando controllers");
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
