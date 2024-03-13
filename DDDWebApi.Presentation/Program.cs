using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using DDDWebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using DDDWebAPI.Infrastructure.CrossCutting.IOC;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
var connection = builder.Configuration["SqlConnection:SqlConnectionString"];
builder.Services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Model DDD", Version = "v1" });
});

// Configura o contêiner Autofac
var containerBuilder = new ContainerBuilder();
containerBuilder.RegisterModule(new ModuleIOC());

// Importa os serviços do IServiceCollection para o contêiner Autofac
containerBuilder.Populate(builder.Services);

// Constrói o contêiner Autofac
var container = containerBuilder.Build();

// Cria o provedor de serviços Autofac
var serviceProvider = new AutofacServiceProvider(container);

var app = builder.Build();

// Define o provedor de serviços para ser o provedor de serviços Autofac
((IApplicationBuilder)app).ApplicationServices = serviceProvider;

// Configura o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Model DDD");
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();