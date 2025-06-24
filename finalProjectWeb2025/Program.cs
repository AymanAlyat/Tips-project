using finalProjectWeb2025.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



                              // هاذ كلاس الكونتكست اللي بدي اتعامل من خلاله مع الداتا بيس
builder.Services.AddDbContext<WebTipsContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("TipseContextStr")));//اسم الكونكشن سترنج اللي حكيتلك عنه رح تستخدمه هون 






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
