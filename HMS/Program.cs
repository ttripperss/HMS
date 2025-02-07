using FluentValidation;
using HMS.Abstractions;
using HMS.Models;
using HMS.Services;
using HMS.Validation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using HMS.Services;
using HMS.Configuration;

internal class Program
{
    private static readonly string AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    private const string ConnectionString = "Server=.;Database=HH;Trusted_Connection=True;";

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add DbContext with SQL Server configuration
        builder.Services.AddDbContext<HmsContext>(options =>
            options.UseSqlServer(ConnectionString));
        var configuration = builder.Configuration;
        builder.Services.Configure<EmailConfiguration>(configuration.GetSection("EmailConfiguration"));

        // Register application services (Transient, Scoped, Singleton as necessary)
        builder.Services.AddTransient<IAppointmentsServices, AppointmentServices>();
        builder.Services.AddTransient<IPatientServices, PatientServices>();
        builder.Services.AddTransient<IDoctorterServices, DoctorServices>();  // Corrected the name
        builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IContextServices, ContextServices>();
        builder.Services.AddScoped<IBillingServices, BillingServices>();
        builder.Services.AddScoped<IEmailService, EmailService>();
        //builder.Services.AddScoped<IConfiguration, Configu>();
        

        // Register FluentValidation Validators
        builder.Services.AddScoped<IValidator<Patient>, PatientValidator>();

        // Register Password Hasher Service
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

        // Register Configuration Service
        builder.Services.AddScoped<IConfigurationService, ConfigurationService>();

        // Add HttpContextAccessor (used to access the current HTTP context in services)
        builder.Services.AddHttpContextAccessor();

        // Configure Authentication using Cookies
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Set appropriate timeout
                options.SlidingExpiration = true; // Keeps the user logged in as long as they remain active
            });

        // Register MVC controllers with views
        builder.Services.AddControllersWithViews();

        // *** Build the application only once ***
        var app = builder.Build();

        // Configure the HTTP request pipeline based on the environment
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Middleware configuration
        app.UseHttpsRedirection();    // Ensure HTTPS usage
        app.UseStaticFiles();         // Serve static files (e.g., CSS, JS)

        app.UseRouting();             // Enable routing

        app.UseAuthentication();      // Enable authentication middleware
        app.UseAuthorization();       // Enable authorization middleware

        // Map controller routes with default route pattern
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // Run the web application
        app.Run();
    }
}
