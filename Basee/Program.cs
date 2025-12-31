using Microsoft.EntityFrameworkCore;
using Basee.Data;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BaseeContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BaseeContext")
        ?? throw new InvalidOperationException("Connection string 'BaseeContext' not found.")
    )
);

var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

// Route par défaut → Create
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Registrations}/{action=Create}/{id?}"
);

app.Run();
