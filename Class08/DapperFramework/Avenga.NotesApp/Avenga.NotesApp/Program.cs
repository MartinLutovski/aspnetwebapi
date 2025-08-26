using Avenga.NotesApp.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Read from appsettings.json, find the property "AppSettings" from the main object
var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettings);

AppSettings appSettingsObject =  appSettings.Get<AppSettings>();

//Dependency Injection
DependencyInjectionHelper.InjectDbContext(builder.Services, appSettingsObject.ConnectionString); // This and the above is called
// option settings pattern, we can use multiple Db if needed
// this is Entity Framework DbContext
// with Entity Framework we can create a code first approach, so the db and tables will be created by the framework
DependencyInjectionHelper.InjectRepositories(builder.Services);

//DependencyInjectionHelper.InjectDapperRepositories(builder.Services, "Server=.;Database=NotesAppDatabase;Trusted_Connection=True;TrustServerCertificate=True");
// the above method is a bad EXAMPLE, never use it, always use the appsettings.json or environment variables
// Inject Dapper Repositories
// with Dapper we cant create a code first approach, we need to have the db and tables created first
DependencyInjectionHelper.InjectAdoRepositories(builder.Services, appSettingsObject.ConnectionString);
// Inject Ado Repositories
DependencyInjectionHelper.InjectServices(builder.Services);


var app = builder.Build();

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
