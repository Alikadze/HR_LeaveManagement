using MediatR;
using System.Reflection;
using HR.LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagment.Application.Contracts.Persistence;
using HR.LeaveManagment.Persistence.Repositories;
using HR.LeaveManagment.Persistence;
using Microsoft.EntityFrameworkCore;
using HR.LeaveManagment.Infrastucture.Mail;
using HR.LeaveManagment.Application.Contracts.Infrastructure;
using HR.LeaveManagment.Application.Models;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Handlers.Commands;
using HR.LeaveManagment.Application.Features.LeaveRequest.Requests.Commands;
using HR.LeaveManagment.Application.Features.LeaveRequest.Handlers.Commands;
using HR.LeaveManagment.Identity;
using HR.LeaveManagment.Identity.Models;
using Microsoft.AspNetCore.Identity;
using HR.LeaveManagment.Application.Contracts.Identity;
using HR.LeaveManagment.Identity.Services;
using HR.LeaveManagment.Application.Models.Identity;
using FluentAssertions.Common;

var builder = WebApplication.CreateBuilder(args);

// Register repositories
builder.Services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
builder.Services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Add AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add MediatR
builder.Services.AddMediatR(typeof(CreateLeaveTypeCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(CreateLeaveAllocationCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(CreateLeaveRequestCommandHandler).Assembly);

// Database context for Leave Management
var connectionString = builder.Configuration.GetConnectionString("LeaveManagementConnectionString");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("The connection string 'LeaveManagementConnectionString' is not configured.");
}

builder.Services.AddDbContext<HrLeaveManagmentDbContext>(options =>
{
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    });
});

//Database context for Identity Management

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var identityConnectionString = builder.Configuration.GetConnectionString("LeaveManagementIdentityConnectionString");
if (string.IsNullOrEmpty(identityConnectionString))
{
    throw new InvalidOperationException("The connection string 'LeaveManagementIdentityConnectionString' is not configured.");
}

builder.Services.AddDbContext<LeaveManagementIdentityDbContext>(options =>
{
    options.UseSqlServer(identityConnectionString).EnableSensitiveDataLogging();
});

// Configure Identity services (add only once)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<LeaveManagementIdentityDbContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));


// Configure email settings
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddSingleton<IEmailSender, EmailSender>();

// Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add Authentication and Authorization middlewares in the correct order
app.UseHttpsRedirection();
app.UseAuthentication(); // Ensure authentication middleware is added before authorization
app.UseAuthorization();

app.MapControllers();

app.Run();
