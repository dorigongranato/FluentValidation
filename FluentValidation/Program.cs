using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

List<Assembly> usedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select((item) => Assembly.Load(item)).ToList();

// Add services to the container.
builder.Services.AddControllers()
                .AddFluentValidation(c =>
                c.RegisterValidatorsFromAssemblies(usedAssemblies)
                //c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                );

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

