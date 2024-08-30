using HMS.Abstractions;
using HMS.Models;
using HMS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<HmsContext>(options
           => options.UseSqlServer("Server=.;Database=HMS;Trusted_Connection=True;"));

// Add services to the container.patient ko addd keia ha
builder.Services.AddTransient<IPatientServices, PatientServices>();
builder.Services.AddControllersWithViews();

// Doctor ko add karn haa
builder.Services.AddTransient<IDoctorterServices, DoctorServices>();
builder.Services.AddControllersWithViews();

// Departmne ko register karna haa
builder.Services.AddTransient<IDepartmentServices, DepartmentServices>();
builder.Services.AddControllersWithViews();



// Billing ko register karna ha
builder.Services.AddTransient<IBillingServices, BillingServices>();
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
