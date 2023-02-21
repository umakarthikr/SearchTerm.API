using FluentValidation;
using FluentValidation.AspNetCore;
using SearchTerm.API.Entities.Context;
using SearchTerm.API.Repository;
using SearchTerm.API.Requests.Model;
using SearchTerm.API.Requests.Validators;
using SearchTerm.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<UserEFCoreInMemoryDBContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepostitory, UserRepository>();
builder.Services.AddMvc();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();

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
