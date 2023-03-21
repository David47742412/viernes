using Dulcepastel.Models.cliente;
using Dulcepastel.Models.login;
using Dulcepastel.Models.tipoDocumento;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.interfaces.transformable.cliente;
using Dulcepastel.Models.utility.interfaces.transformable.usuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Cliente>();
builder.Services.AddScoped<TipoDocumento>();
builder.Services.AddScoped<Login>();
builder.Services.AddScoped<ClienteTransformable>();
builder.Services.AddScoped<UsuarioTransformable>();

builder.Services.AddSingleton(DulcepastelContext.GetInstance(builder.Configuration.GetConnectionString("conexionDocker")!));
builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.RootDirectory = "/Login";
    options.Conventions.AddPageRoute("/Home", "");
    
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
