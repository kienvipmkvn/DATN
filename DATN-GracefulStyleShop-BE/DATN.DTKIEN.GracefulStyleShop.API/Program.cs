﻿using CloudinaryDotNet;
using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.BL.Services;
using DATN.DTKIEN.GracefulStyleShop.DL.Database;
using DATN.DTKIEN.GracefulStyleShop.DL.Helpers;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.DL.Repository;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IDatabaseConnection, DatabaseConnection>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDL, ProductDL>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFileDL, FileDL>();
builder.Services.AddScoped<IRegionDL, RegionDL>();
builder.Services.AddScoped<IAddressReceiveDL, AddressReceiveDL>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IAddressReceiveService, AddressReceiveService>();
builder.Services.AddScoped<IUserTokenDL, UserTokenDL>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerDL, CustomerDL>();
builder.Services.AddScoped<IAdminDL, AdminDL>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserTokenService, UserTokenService>();
builder.Services.AddScoped<IUserTokenDL, UserTokenDL>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDL, OrderDL>();
builder.Services.AddScoped<ICartDL, CartDL>();
builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<IStatisticDL, StatisticDL>();
builder.Services.AddScoped<ICreditCardService, CreditCardService>();
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// tạo các public api
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AllowAnonymousPolicy", policy =>
        policy.RequireAssertion(context => true));
});

// Cấu hình redis
//var redis = ConnectionMultiplexer.Connect("localhost");
//builder.Services.AddSingleton<IConnectionMultiplexer>(redis);
// Bỏ bắn lỗi mặc định Atrribute
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Config respone để không chuyển hết về chữ thường
builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddSingleton(new Cloudinary(new Account(
    "dqywrcgrr",
    "511812445438653",
    "LaDWdP21mxTWyhZ2d5c08LkVYsk"
)));

// Get connectionString
DatabaseContext.connectionString = builder.Configuration.GetConnectionString("MySqlLocal");

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseCors(x => x.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod()
          );
app.MapControllers();

app.Run();
