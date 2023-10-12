using self_messaging.Configurations.Extensions;
using self_messaging.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.RegisterCustomServices(builder.Configuration);

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
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MessageHub>("/messageHub");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Message}/{action=Index}/{id?}");
});

app.Run();
