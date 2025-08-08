var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Esto es necesario para que los archivos estáticos funcionen

app.UseRouting();
app.UseAuthorization();

// Configurar la ruta predeterminada para el controlador y la acción
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Agregar la ruta para los productos
app.MapControllerRoute(
    name: "productos",
    pattern: "productos",
    defaults: new { controller = "Productos", action = "Index" });

app.Run();
