using PortfolioService.Application.Interfaces;
using PortfolioService.Infrastructure.DependencyInjection;

//validation
using FluentValidation;
using FluentValidation.AspNetCore;
using PortfolioService.Application.Validators;
using System.Security.AccessControl;

//Customize the validation error response
using Microsoft.AspNetCore.Mvc;
using PortfolioService.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Application layer
builder.Services.AddScoped<IPortfolioService, PortfolioService.Application.Services.PortfolioService>();

// Register Infrastructure layer
builder.Services.AddInfrastructure(builder.Configuration);

//DTOs Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePortfolioRequestValidator>();

//Customize the validation error response
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        var response = new ApiErrorResponse
        {
            Success = false,
            Message = "Validation failed",
            Errors = errors
        };

        return new BadRequestObjectResult(response);
    };
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();