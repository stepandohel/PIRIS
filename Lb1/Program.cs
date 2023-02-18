using Lb1.DB;
using Lb1.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
    ));

builder.Services.AddSwaggerGen();
var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    await context.Database.MigrateAsync();
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(x => { x.DocumentTitle = "Swagger"; x.SwaggerEndpoint("/swagger/v1/swagger.json", "SwaggerMeetup"); x.RoutePrefix = string.Empty; });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
