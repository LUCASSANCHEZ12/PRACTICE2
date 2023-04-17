var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var configurationbuilder = new ConfigurationBuilder()
        .SetBasePath(app.Environment.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: false, reloadChange: true)
        .AddJsonFile($"appsettings.{app.Enciroment.EnviromentName},json", optional: false, reloadChange: true)
        .AddEnviormentVariables();

IConfiguration Configuration = configurationbuilder.build();

string siteTitle = Configuration.GetSection("Title").Value;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
