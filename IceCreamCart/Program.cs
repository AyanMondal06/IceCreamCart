using Microsoft.EntityFrameworkCore;
using IceCreamCart.Infrastructure;
using IceCreamCart.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IceCreamCartContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("IceCreamCartContext"))
);



var app = builder.Build();
using (var Scope = app.Services.CreateScope())
{
    var services = Scope.ServiceProvider;
    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
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
            name: "areas",
            pattern: "{area:exists}/{controller=Page}/{action=Index}/{id?}");
/*app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Page}/{action=Index}/{id?}");*/

app.Run();
