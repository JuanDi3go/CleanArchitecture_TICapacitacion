using FluentValidation;
using NorthWay.Entities.Exceptions;
using NorthWind.WebExceptionsPresenter;
using NorthWind.InversionOfControl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Filters.Add(new ApiExceptionFilterAtribute(new Dictionary<Type, IExceptionHandler>
{
    {
        typeof(GeneralException), new GeneralExceptionHandler()
    },
    {
        typeof(ValidationException), new ValidationExceptionHandler()
    }
})));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddNorthWindServices(builder.Configuration);

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
