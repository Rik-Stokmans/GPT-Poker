using DataLayer.Services;
using LogicLayer.Core;
using LogicLayer.Models;

var builder = WebApplication.CreateBuilder(args);

Core.Init(
    new DatabaseEntityService<Account>(), 
    new DatabaseEntityService<Section>(), 
    new DatabaseEntityService<Unit>(),
    new DatabaseEntityService<Lesson>(),
    new DatabaseEntityService<SectionProgress>(),
    new DatabaseEntityService<UnitProgress>(),
    new DatabaseEntityService<LessonProgress>());

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// Add authorization services here
builder.Services.AddAuthorization();

builder.Services.AddSession();

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

app.UseSession();

app.Run();

