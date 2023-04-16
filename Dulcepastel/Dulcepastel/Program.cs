using System.Text;
using Dulcepastel.Models.cliente;
using Dulcepastel.Models.login;
using Dulcepastel.Models.tipoDocumento;
using Dulcepastel.Models.utility.context;
using Dulcepastel.Models.utility.jwt;
using Dulcepastel.Models.utility.transformable.cliente;
using Dulcepastel.Models.utility.transformable.usuario;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Cliente>();
builder.Services.AddScoped<TipoDocumento>();
builder.Services.AddScoped<Login>();
builder.Services.AddScoped<ClienteTransformable>();
builder.Services.AddScoped<UsuarioTransformable>();
builder.Services.AddSingleton(DulcepastelContext.GetInstance(builder.Configuration.GetConnectionString("conexion")!));
var data = new List<string> { builder.Configuration["Jwt:JWT_KEY"], builder.Configuration["Jwt:Issuer"], builder.Configuration["Jwt:Audience"], builder.Configuration["Jwt:Subject"] };
builder.Services.AddSingleton(JwtConfig.GetInstance(data: data));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:JWT_KEY"]))
        };
    });

builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.DataProtectionProvider = new EphemeralDataProtectionProvider();
        options.Cookie.Name = ".Dulcepastel.Session";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.ClaimsIssuer = builder.Configuration["Jwt:Issuer"];
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.Cookie.IsEssential = true;
        //options.Validate();
    });
builder.Services.AddHttpContextAccessor();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
