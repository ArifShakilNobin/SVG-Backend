using Microsoft.EntityFrameworkCore;
using Resturant.Repository;
using Svg.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddTransient<IRectangularRepo, RectangularRepo>();



#region postgreSQL now support .net datetime

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


#endregion postgreSQL now support .net datetime


#region cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(
           name: "AllowOrigin",
           builder =>
           {
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
           });
});




#endregion cors





var app = builder.Build();






// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Health Tracking Authorization v1"));
//}

//else
//    app.UseSwagger();
//app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API"));


app.UseHttpsRedirection();

app.UseCors("AllowOrigin");


app.MapControllers();

app.Run();

