using ConcertBooking.Web.Data;
using Microsoft.EntityFrameworkCore;

// DI container or Services
// 

// WebApplicationBuilder will do the work of setting up the DI container
// and configuring the application pipeline.
// will do configuration like web server, routing, etc.
// Setting host and once DI Container setup is done,
// it will go for middleware configuration

var builder = WebApplication.CreateBuilder(args);

// below line will add the ApplicationDbContext to the DI container
// ApplicationDbContext is the class that will interact with the database
// It will use the connection string from the appsettings.json file
// We are passing the options to the DbContext constructor
builder.Services.AddDbContext <ApplicationDbContext>(options => 
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

// Middlewares:
// Middleware is a component that is executed in the request pipeline
// and can handle requests and responses.
// Middleware can be used for various purposes like authentication, logging, etc.
// Middleware are executed in the order they are added to the pipeline
// and can short-circuit the request processing.

// UseHttpsRedirection will redirect HTTP requests to HTTPS
app.UseHttpsRedirection();
// UseStaticFiles will serve static files like CSS, JS, images, etc.
app.UseStaticFiles();

// UseRouting will enable routing in the application
// if removed, the application will not be able to route requests to controllers
// and will throw an exception when trying to access any controller action.
app.UseRouting();

app.UseAuthorization();

// MapControllerRoute will map the incoming requests to the appropriate controller and action
// The default route is defined as {controller=Home}/{action=Index}/{id?}
// The controller is Home, the action is Index, and id is optional
// This means that if no controller or action is specified in the URL,
// the HomeController's Index action will be called.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Test}/{action=ShowButton}/{id?}");

app.Run();
