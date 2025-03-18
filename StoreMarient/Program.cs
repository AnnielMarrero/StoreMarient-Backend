using StoreMarient.Data;
using System;
using Microsoft.EntityFrameworkCore;
using StoreMarient.Mapper;
using StoreMarient.Services.Base;
using StoreMarient.Services;
using StoreMarient.Repositories.Base;

AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(Directory.GetCurrentDirectory(), "App_Data"));
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add SQLite database connection
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); 

//adding automapper
builder.Services.AddAutoMappers(MappingProfile.CreateExpression().AddAutoMapper());

//adding services
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IMicaService, MicaService>();
builder.Services.AddScoped<ICoverStockService, CoverStockService>();

builder.Services.AddScoped<IPdfService, PdfService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Run Seeder
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<StoreContext>();
    await DbSeeder.SeedAsync(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(option => option.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
