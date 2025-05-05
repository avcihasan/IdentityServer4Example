using IdentityServer;
using IdentityServerHost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(Config.GetApiResources)
    .AddInMemoryApiScopes(Config.GetApiScopes)
    .AddInMemoryClients(Config.GetClients)
    .AddInMemoryIdentityResources(Config.GetIdentityResources)
    .AddTestUsers(Config.Users.ToList())
    .AddDeveloperSigningCredential();
builder.Services.AddRazorPages();

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
app.UseIdentityServer();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
