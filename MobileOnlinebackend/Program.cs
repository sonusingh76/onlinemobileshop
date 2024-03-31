using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MobileOnlineShopSystem.MobileMicroservice.Business_Layer.Service;
using MobileOnlineShopSystem.MobileMicroservice.Data_Access_Layer.Repository;
using MobileOnlineShopSystem.OrderMicroservice.Business_Layer.Service;
using MobileOnlineShopSystem.OrderMicroservice.BusinessLayer.Service;
using MobileOnlineShopSystem.OrderMicroservice.Data_Access_Layer.Repository;
using MobileOnlineShopSystem.PaymentMicroservice.Business_Layer.Service;
using MobileOnlineShopSystem.PaymentMicroservice.Data_Access_Layer.Repository;
using MobileOnlineShopSystem.PaymentMicroservice.DataAccessLayer.RepositoryImplementation;
using MobileOnlineShopSystem.UserMicroservice.Business_Layer.Service;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Data;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserData>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MobileShop")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IMobileService, MobileService>();
builder.Services.AddScoped<IMobileRepository, MobileRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mobile Shop", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT <strong>Authorization</strong> header using the Bearer scheme. <br/> 
                      Enter your token in the text input below.
<br/>Example: <i>'12345abcdef'</i>",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
 {
 {
 new OpenApiSecurityScheme
 {
 Reference = new OpenApiReference
 {
 Type = ReferenceType.SecurityScheme,
 Id = "Bearer"
 }
 },
 Array.Empty<string>()
 }
 });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = false,
         ValidateAudience = false,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
     };
 });
var app = builder.Build();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

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
