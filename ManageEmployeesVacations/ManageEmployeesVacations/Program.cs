﻿
using ManageEmployeesVacations.Data;
using ManageEmployeesVacations.Mappers;
using ManageEmployeeVacationsVacations.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEmployeeMapper, EmployeeMapper>(); ;
builder.Services.AddTransient<IEmployeeVacationMapper, EmployeeVacationMapper>(); ;
builder.Services.AddTransient<IVacationMapper, VacationMapper>(); ;
builder.Services.AddTransient<IVacationRequestMapper, VacationRequestMapper>();
builder.Services.AddTransient<IEmployeeVacationDTOPOSTMapper, EmployeeVacationDTOPOSTMapper>();
builder.Services.AddTransient<IGenderMapper, GenderMapper>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



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
