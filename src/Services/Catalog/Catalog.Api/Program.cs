var builder = WebApplication.CreateBuilder(args);

//add services to the conatianer

var app = builder.Build();


//configure HTTP Request pipeline

app.Run();
