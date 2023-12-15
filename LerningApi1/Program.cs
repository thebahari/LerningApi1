using CityInfo.API.Services;
using LerningApi1;
using LerningApi1.DbContex;
using LerningApi1.Repository;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("bin/logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option =>
{
    option.ReturnHttpNotAcceptable=true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Host.UseSerilog();
builder.Services.AddSingleton<CitiesDataStore>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DbApiLerning>(option =>
option.UseSqlServer(
    //Getting the address of the connection string from the appsetting file
    builder.Configuration["ConnectionStrings:SqlLite"])) ;
builder.Services.AddScoped<ICityRepository,CityRepository>();
#if DEBUG
builder.Services.AddTransient<IMailService,LocalMailService>();
#endif
var app = builder.Build();

#region start PipeLine
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
#endregion

app.Run();
