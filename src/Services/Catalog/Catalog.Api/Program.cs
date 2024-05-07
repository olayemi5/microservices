
var builder = WebApplication.CreateBuilder(args);

//add services to the conatianer
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(Loggingbehaviuor<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddCarter();

builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

//configure HTTP Request pipeline
app.MapCarter();

app.UseExceptionHandler(opts => { });

app.Run();
