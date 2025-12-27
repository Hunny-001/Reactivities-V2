using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();


builder.Services.AddDbContext<AppDbContext>(x =>
//Here it means AppDbContext.cs is a scoped service
// here every http request gets its own instance of AppDbContext, and disposed once its ends, it means
//if 100 users visit your site, there will be 100 separate instances of that service
//So each user is independent of reading/inserting/deleting data, no two users data will be interupted(If they are interupted/clash then it will throw error)
//Hence it also prevents data leaks btw users.


{
    x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    //DefaultConnection is defined in API/appsettings.development.json file
});
builder.Services.AddCors();
var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:3000", "http://localhost:3000"));
//here we are adding CORS policy to allow requests from our React app (client) running on localhost:3000
app.MapControllers(); //2. Once we execute dotnet run command then there is routing i.e here localhost:6969/WeatherForecast



using var scope = app.Services.CreateScope();
//Creates a new service scope from the app’s dependency injection(DI) container.
//Needed because AppDbContext is registered as a scoped service, so it must be resolved within a scope.
//when using block ends, the scope gets disposed, and all scoped services are cleaned up.

var xx = scope.ServiceProvider;
//Retrieves the service provider that gives access to all registered services.

try
{
    var obj = xx.GetRequiredService<AppDbContext>();
    //GetRequiredService<T> : Give me the service of type T , returns null if T not found.
    //Gets your database context (EF Core DbContext) instance, which connects to the database.

    await obj.Database.MigrateAsync();
    //Applies any pending EF Core migrations automatically when the app starts.
    //This ensures your database schema is up to date with your model whenever the code runs.
    //It is imp to call before seeding data, bcoz table rhega tb hi data seed hoga na.

    await DbInitializer.SeedData(obj);
    //Calls your custom method to seed initial data.
}
catch (Exception ex)
{
    var logger = xx.GetRequiredService<ILogger<Program>>();
    //From the DI container, give me a logger that logs messages for the Program class
    //ILogger<T> is a generic logger interface — it automatically tags logs with the type name T (here T is Program.cs)

    logger.LogError(ex, "Exception occured while migrating/seeding data");
}




app.Run(); //1. It will run the API project, with dotnet run command
