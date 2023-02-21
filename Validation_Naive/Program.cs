using Microsoft.AspNetCore.Mvc;
using Validation.Data;
using Validation.Services;
using Validation.Services.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();


app.MapGet("/api/customers", ([FromServices] ICustomerService service) =>
{
    return Results.Ok(service.GetCustomers());
});

app.MapGet("/api/customers/{id}", ([FromServices] ICustomerService service, int id) =>
{
    return Results.Ok(service.GetCustomerById(id));
});

app.MapPost("/api/customers", ([FromServices] ICustomerService service, CustomerCreateDto customer) =>
{
    var result = service.CreateCustomer(customer);

    if (!result.Success && result.ErrorCode == 400)
        return Results.BadRequest(result);

    return Results.Ok(result);
});

app.MapPut("/api/customers/{id}", ([FromServices] ICustomerService service, CustomerCreateDto customer, int id) =>
{
    var result = service.EditCustomer(id, customer);

    if (!result.Success && result.ErrorCode == 400)
        return Results.BadRequest(result);

    if (!result.Success && result.ErrorCode == 404)
        return Results.NotFound(result);

    return Results.Ok(result);
});

app.Run();
