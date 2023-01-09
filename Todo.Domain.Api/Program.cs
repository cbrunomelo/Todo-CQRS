using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Api;
using Todo.Domain.Api.Extensions;
using Todo.Domain.Api.Services;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Data;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;
using Todo.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });


//dependencias
builder.Services.AddDbContext<TodoDataContext>(opt => opt.UseSqlite("DataSource=..\\Todo.Domain.Infra\\app.db;Cache=Shared;"));


//user dependencias
builder.Services.AddTransient<UserHandler, UserHandler>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

//Todo dependencias
builder.Services.AddTransient<TodoHandler, TodoHandler>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<ITokenService, TokenService>();

builder.Services.AddSwagger();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.JwtKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
