﻿using Data.SqlServer.Context;
using Data.SqlServer.Data;
using Infrastructure.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
#region Cấu hình ghi logging vao database
var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
                .MinimumLevel.Override("Serilog", LogEventLevel.Error)
                .Enrich.FromLogContext()
                .Enrich.WithClientIp()
                .Enrich.WithClientAgent()
                .CreateLogger();

Log.Logger = logger;
builder.Logging.AddSerilog(logger);
builder.Host.UseSerilog();
#endregion
#region          Thêm LOGIN header Api Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});
#endregion
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
#region    Cấu hình DataContext
//Nạp pendency vao project
DependencyContainer.RegisterIoC(builder.Services, builder.Configuration);
//Api cho nhiều trình duyệt, ứng dụng khác sử dụng được bằng các cấu hình
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
//Kết nối sever database context cùng với Auth + Identity + Token
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
//Kết nối sever database context
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductStore"));
});
#endregion
#region config AUTO Map Map giữa ModelEntities và DataSql Database
builder.Services.AddAutoMapper(typeof(Program));
#endregion
#region  Đăng ký để sử dụng Repository
//Life cycle DI: AddSignleton(), AddTransient(), AddScoped()
//builder.Services.AddScoped<IAccountRepository, AccountRepository>();
#endregion
#region  KHai báo lớp đăng nhập hệ thống Auth
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;     //Mức default Auth
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;        //Mức độ thử thách
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;                 //Mức độ 3
}).AddJwtBearer(options => {                                                        //Cấu hình thêm 1 số thứ như thời gian sống, lấy ở đâu     
    options.SaveToken = true;                                                       //Token có save không 
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,                                      //Cấp phép
        ValidateAudience = true,                                    //
        ValidateIssuerSigningKey = true,                            //
        ValidAudience = builder.Configuration["JWT:ValidAudience"], //Lấy bên Appsetting.json
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],     //Lấy bên Appsetting.json
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //Thêm LOGIN header Api Swagger
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1/swagger.json", "My API V1"); });
}

app.UseHttpsRedirection();
app.UseAuthorization();
//thêm quyền đăng nhập
app.UseAuthentication();

app.MapControllers();

app.Run();
