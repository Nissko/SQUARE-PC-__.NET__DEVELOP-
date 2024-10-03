using Autofac;
using Autofac.Extensions.DependencyInjection;
using squarePC.API.Infrastructure;
using squarePC.Application.Application.Extensions;
using squarePC.Infrastructure.Extensions;

ContainerBuilder build = new ContainerBuilder();
build.RegisterModule(new ApplicationModule());

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddSquarePcCollectionInfrastructure(builder.Configuration)
    .AddApplication();

builder.Host.UseServiceProviderFactory(new AutofacChildLifetimeScopeServiceProviderFactory(build.Build()));

// Add services to the container.

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
