var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<Frontend_ScaleM.Services.ClientesService>();
builder.Services.AddScoped<Frontend_ScaleM.Services.IClientesService, Frontend_ScaleM.Services.ClientesService>();
// ProductosService
builder.Services.AddHttpClient<Frontend_ScaleM.Services.ProductosService>();
builder.Services.AddScoped<Frontend_ScaleM.Services.IProductosService, Frontend_ScaleM.Services.ProductosService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Esto es necesario para que los archivos est�ticos funcionen

app.UseRouting();
app.UseAuthorization();

// Configurar la ruta predeterminada para el controlador y la acci�n
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Agregar la ruta para los productos
app.MapControllerRoute(
    name: "productos",
    pattern: "productos",
    defaults: new { controller = "Productos", action = "Index" });

app.Run();
