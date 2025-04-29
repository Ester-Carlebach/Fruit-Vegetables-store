using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//הזרקת תלויות
builder.Services.AddScoped<IDal.IDallCustomer, Dal.Customer>();
builder.Services.AddScoped<IBll.Customer, Bll.Customer>();
builder.Services.AddScoped<IDal.IDallCategory, Dal.Catrgory>();
builder.Services.AddScoped<IBll.IBlCategory, Bll.Category>();
builder.Services.AddScoped<IDal.IDallCompany, Dal.Company>();
builder.Services.AddScoped<IBll.IBlCompany, Bll.Company>();
builder.Services.AddScoped<IDal.IdalPruducts,Dal.Product>();
builder.Services.AddScoped<IBll.product, Bll.product>();
builder.Services.AddScoped<IDal.Shop, Dal.Shop>();
builder.Services.AddScoped<IBll.Shop, Bll.Shop>();
builder.Services.AddScoped<IDal.ShopDetails, Dal.ShopDetails>();
builder.Services.AddScoped<IBll.ShopDetails, Bll.ShopDetails>();
//.מסד נתונים

builder.Services.AddDbContext<Dal.models.ShopContext>
(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

//שגיאת קורס הרשאת גישה 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
            builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
