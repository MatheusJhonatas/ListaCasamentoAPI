using Data.Mappings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<ListaCasamentoDataContext>();
var app = builder.Build();
app.MapControllers();

app.Run();
