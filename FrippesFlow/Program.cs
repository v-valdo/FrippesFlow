using FrippesFlow.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FrippesFlowContext>(options =>
 options.UseSqlite(builder.Configuration.GetConnectionString("Sqllite")));

builder.Services.AddScoped<CostCalculation>();
builder.Services.AddScoped<SalesService>();
builder.Services.AddScoped<ResultService>();

builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<IResultRepository, ResultRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
