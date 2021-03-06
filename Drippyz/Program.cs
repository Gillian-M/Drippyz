using Drippyz.Data;
using Drippyz.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



//DbContext configuration (used nuget packet manager for usesqlserver)  Configrire sql server (which c# classes it needs to translate)
//USE SQL Server ;installed and used mcrosoft entity framework core and defined the connection string
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString") ?? throw new InvalidOperationException("Connection string 'ProductsContext' not found.")));

//Services configuration 
builder.Services.AddScoped<IStoresService, StoresService>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddScoped<AppDbInitializer>(); //can be placed among other "AddScoped" - above: var app = builder.Build();

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

SeedDatabase();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//Seed database (Iapplication builder)
//AppDbInitializer.Seed(app);
void SeedDatabase() //can be placed at the very bottom under app.Run()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<AppDbInitializer>();
        dbInitializer.Initialize();
    }
}