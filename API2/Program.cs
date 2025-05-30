using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, (opt) =>
    {
        opt.Authority = "https://localhost:7200";
        opt.Audience = "resource_api2";

    });
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("ReadOrder", policy =>
    {
        policy.RequireClaim("scope", ["api2.read"]);
    });
    opt.AddPolicy("UpdateOrCreateOrder", policy =>
    {
        policy.RequireClaim("scope", ["api2.create", "api2.update"]);
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
