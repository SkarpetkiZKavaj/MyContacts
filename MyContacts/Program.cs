using Microsoft.EntityFrameworkCore;
using MyContacts_BAL.Interface;
using MyContacts_BAL.Service;
using MyContacts_DAL.EF;
using MyContacts_DAL.Interface;
using MyContacts_DAL.Repository;
using MyContacts.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ContactsContext>();
builder.Services.AddAutoMapper(typeof(ContactProfile));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IService, ContactService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();