using Hospital.IRepo;
using Hospital.Repo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using P.IRepo;
using P.Models;
using P.Repo;
using WebApplication2.IRepo;
using WebApplication2.Repo;
using WebApplication3.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HospitalContext>(
    options =>
    {
        options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("cs"));
    }
    
    );
builder.Services.AddScoped<IPatient, PatientRepo>();
builder.Services.AddScoped<IRoom, RoomRepo>();
builder.Services.AddScoped<IDoctor, DoctorRepo>();
builder.Services.AddScoped<IDeparetment, DepartmentReprository>();
builder.Services.AddScoped<IAppointment, AppointmentRepo>();
builder.Services.AddScoped<IMedicalRecord, MedicalRecordRepo>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(Options =>
{
    Options.Password.RequireDigit = false;
    Options.Password.RequireLowercase = false;
    Options.Password.RequireUppercase = false;
    Options.Password.RequireNonAlphanumeric = false;
    Options.User.RequireUniqueEmail = false; // Set to true if email uniqueness is required
    Options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"; // Add or remove characters as needed

    //Options.User.AllowedUserNameCharacters = @"^[a-zA-Z]+(\s[a-zA-Z]+)?$";
    //Options.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<HospitalContext>();
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.Cookie.HttpOnly = true; // Make cookie HttpOnly for security
//    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensure cookies are only sent over HTTPS
//    options.Cookie.SameSite = SameSiteMode.Strict; // Prevent cross-site cookie sharing
//    options.Cookie.IsEssential = true; // Required for GDPR compliance

//    options.ExpireTimeSpan = TimeSpan.Zero; // Do not set an expiration time, so it expires on session end
//    options.SlidingExpiration = false; // Prevent sliding expiration to keep it session-based
//    options.Cookie.MaxAge = null; // Ensure no explicit expiration (session cookie)
//});
builder.Services.AddSingleton(x =>
new PaypalClient(builder.Configuration["PayPalOptions:ClientId"],
builder.Configuration["PayPalOptions:ClientSecret"],
builder.Configuration["PayPalOptions:Mode"]
)
    );
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
