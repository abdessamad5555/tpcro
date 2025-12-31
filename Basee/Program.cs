using Microsoft.EntityFrameworkCore;
using Basee.Data;
using Basee.Repositories;
using Basee.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BaseeContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BaseeContext")
        ?? throw new InvalidOperationException("Connection string 'BaseeContext' not found.")
    )
);

// 🔥 IMPORTANT
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Registrations}/{action=Create}/{id?}"
);

app.Run();
