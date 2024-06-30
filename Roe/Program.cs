using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Roe.Entities;
using Roe.Policies;
using Roe.Services;
using Roe.Services.Factories;
using Roe.Services.OrderStatuses;
using Roe.Services.OrderTemplates;
using Roe.Services.Processes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RoeContext>(opt =>
    opt.UseSqlite("Data Source=roe.db")
);
builder.Services
    .AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<RoeContext>()
    .AddUserManager<CustomUserManager>();
builder.Services.AddScoped<FactoryService>();
builder.Services.AddScoped<ProcessService>();
builder.Services.AddScoped<OrderTemplateService>();
builder.Services.AddScoped<OrderStatusService>();
builder.Services.AddScoped<FactoryPolicy>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddAuthentication();

builder.Services.AddAuthorization();


builder.Services.AddCors(o => o.AddPolicy("DevPolicy", builder =>
{
    builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RoeContext>();
    // context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseCors("DevPolicy");

app.Run();