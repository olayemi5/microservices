var builder = WebApplication.CreateBuilder(args);

//add services to the conatianer
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

//configure HTTP Request pipeline
app.MapCarter();

app.Run();
