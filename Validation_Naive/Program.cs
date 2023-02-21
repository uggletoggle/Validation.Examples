using Microsoft.AspNetCore.Mvc;
using Validation.Data;
using Validation.Domain;
using Validation.Services;

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
    service.CreateCustomer(customer);
    return Results.Ok();
});

app.MapPut("/api/customers/{id}", ([FromServices] ICustomerService service, CustomerCreateDto customer, int id) =>
{
    service.EditCustomer(id, customer);
    return Results.Ok();
});

app.Run();
