#region Using
using DemoTelerik.Modules.Injection;
using DemoTelerik.Modules.Mapper;
#endregion


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
				// Maintain property names during serialization. See:
				// https://github.com/aspnet/Announcements/issues/194
				.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());
// Add Kendo UI services to the services container"
builder.Services.AddKendo();
builder.Services.AddRazorPages();

builder.Services.AddMapper();//Mapper Extensiones
builder.Services.AddInjection(builder.Configuration);//Injection Extensiones

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();