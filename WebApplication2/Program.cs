using Microsoft.EntityFrameworkCore;
using SGME.Model;
using SGME.Repositories;
using SGME.Services;
using WebApplication2.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConecctString = builder.Configuration.GetConnectionString("Connection");


builder.Services.AddDbContext<TestContext>(options => options.UseSqlServer(ConecctString));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Configuration

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
builder.Services.AddScoped<IUserTypeService, UserTypeService>();

builder.Services.AddScoped<IUsageHistoryRepository, UsageHistoryRepository>();
builder.Services.AddScoped<IUsageHistoryService, UsageHistoryService>();

builder.Services.AddScoped<IRecordRepository, RecordRepository>();
builder.Services.AddScoped<IRecordService, RecordService>();

builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<IPlatformService, PlatformService>();

builder.Services.AddScoped<IPermissionsRepository, PermissionsRepository>();
builder.Services.AddScoped<IPermissionsService, PermissionsService>();

builder.Services.AddScoped<IPermissionPerUserTypeRepository, PermissionPerUserTypeRepository>();
builder.Services.AddScoped<IPermissionPerUserTypeService, PermissionPerUserTypeService>();

builder.Services.AddScoped<IContentUserRepository, ContentUserRepository>();
builder.Services.AddScoped<IContentUserService, ContentUserService>();

builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IContentService, ContentService>();

builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<ICommentsService, CommentsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
