using GenericImplementation.Api.DbContexts;
using GenericImplementation.Api.Generics;
using GenericImplementation.Api.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services
.AddControllers()
.AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});
builder.Services.AddDbContext<GenericDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddScoped(typeof(GenericDataService<>));
builder.Services.
        AddMvc(o => o.Conventions.Add(
            new GenericControllerRouteConvention()
        )).
        ConfigureApplicationPartManager(m =>
            m.FeatureProviders.Add(new GenericTypeControllerFeatureProvider()
        ));

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
