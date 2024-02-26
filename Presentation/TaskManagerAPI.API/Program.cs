using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TaskManagerAPI.Application;
using TaskManagerAPI.Persistence.ServicesRegistration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddServicesRegistration();
builder.Services.AddApplicationServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true ,//oluşturulacak tokeni kimlerin tüketeciğini tanımladığımız yer
            ValidateAudience = true,//oluşturlan tokenın kimin dağıtacağını tanımladıığımız yer
            ValidateLifetime = true,//tokenın süresi
            ValidateIssuerSigningKey = true,//üreticelcek token değerinin uygulamaya ait bir değer olduğunu ifade eden 
            //bir security key in doğrulamasıdır.
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
        };
    });
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();