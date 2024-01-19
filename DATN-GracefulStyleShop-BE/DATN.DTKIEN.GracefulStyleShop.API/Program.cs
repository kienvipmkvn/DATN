using CloudinaryDotNet;
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
    "dteiwcmyb",
    "162596935736952",
    "F8VK5KjbJCtrJAlQNJjr858ox_s"
)));

// Get connectionString
var dataSource = Environment.GetEnvironmentVariable("MYSQL_SERVER") ?? "host.docker.internal";
var port = Environment.GetEnvironmentVariable("MYSQL_PORT") ?? "3306";
var initialCatalog = Environment.GetEnvironmentVariable("MYSQL_INITIAL_CATALOG") ?? "datn";
var userName = Environment.GetEnvironmentVariable("MYSQL_USERNAME") ?? "root";
var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD") ?? "123456";
var connectionString = $"Server={dataSource};Port={port};Database={initialCatalog};Uid={userName};Pwd={password}";
Console.WriteLine(connectionString);
DatabaseContext.connectionString = connectionString;

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
