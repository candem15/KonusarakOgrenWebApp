using DataStore.SQL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using System;
using UseCases;
using Microsoft.AspNetCore.Identity;
using WebApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var env = builder.Environment;

//Identity Area
var connectionString = builder.Configuration.GetConnectionString("SqlConnectionIdentity");
builder.Services.AddDbContext<AccountContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AccountContext>();

// Add services to the container.
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddDbContext<AppDbContext>();

//Repositories
services.AddScoped<ICategoryRepo, CategoryRepo>();
services.AddScoped<IProductRepo, ProductRepo>();
services.AddScoped<IBrandRepo, BrandRepo>();
services.AddScoped<ICommentRepo, CommentRepo>();
services.AddTransient<ICustomerRepo, CustomerRepo>();

//Categories
services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();

//Products
services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();

//Brands
services.AddTransient<IViewBrandsUseCase, ViewBrandsUseCase>();

//Comments
services.AddTransient<IViewCommentsUseCase, ViewCommentsUseCase>();

//Customers
services.AddTransient<IViewCustomersUseCase, ViewCustomersUseCase>();

//Auth Policies
services.AddAuthorization(options =>
            {
                options.AddPolicy("ProductPolicy", policy =>
                    policy.RequireAssertion(context =>
                    context.User.HasClaim(c => (c.Value == "Customer" || c.Value == "Admin" || c.Value == "SysAdmin"))));
                options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
                options.AddPolicy("CustomerOnly", p => p.RequireClaim("Position", "Customer"));
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
});

//Database Prep (Auto Migrations)
PrepDb.PrepPopulation(app);

app.Run();
