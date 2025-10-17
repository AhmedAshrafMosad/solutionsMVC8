using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Interfaces;
using SchoolManagement.Repositories;
using SchoolManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to container
builder.Services.AddControllersWithViews();

// Database Context
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories and Services
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ICourseService, CourseService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// **PROPER ROUTE CONFIGURATION**
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Custom routes for pretty URLs
app.MapControllerRoute(
    name: "students",
    pattern: "students/{action=GetAll}/{id?}",
    defaults: new { controller = "Student" });

app.MapControllerRoute(
    name: "departments",
    pattern: "departments/{action=GetAll}/{id?}",
    defaults: new { controller = "Department" });

app.MapControllerRoute(
    name: "courses",
    pattern: "courses/{action=GetAll}/{id?}",
    defaults: new { controller = "Course" });

// Default route (must be last)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the database.");
    }
}

app.Run();