using DataCon;
using Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.Classes;
using Repository.Contracts;
using Services.Classes;
using Services.Contracts;
using System.Text;
using System.Text.Json.Serialization;
using Unit.Classes;
using Unit.Contracts;

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
builder.Services.AddAuthorization();
//services.AddIdentity<IUser, IdentityRole>().AddEntityFrameworkStores<DataContext>();


builder.Services.AddScoped<IEmployeeMapper, EmployeeMapper>(); ;
builder.Services.AddScoped<IEmployeeVacationMapper, EmployeeVacationMapper>(); ;
builder.Services.AddScoped<IVacationMapper, VacationMapper>(); ;
builder.Services.AddScoped<IVacationRequestMapper, VacationRequestMapper>();
builder.Services.AddScoped<IEmployeeVacationDTOPOSTMapper, EmployeeVacationDTOPOSTMapper>();
builder.Services.AddScoped<IGenderMapper, GenderMapper>();
builder.Services.AddScoped<IVacationRequestService, VacationRequestService>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IVacationRepository, VacationRepository>();
builder.Services.AddScoped<IEmployeeVacationsRepository, EmployeeVacationsRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IVacataionRequestsRepository, VacationRequestsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
//builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IVacationService, VacationService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IEmployeeVacationService, EmployeeVacationService>();
builder.Services.AddScoped<IUnitOfWork, AUnitOfWork>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidAudience = builder.Configuration["Jwt:Issuer"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();
app.UseAuthentication();


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
