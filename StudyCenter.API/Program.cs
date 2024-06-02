using StudyCenter.Shared.Infraestrutura.Backend.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Pass the configuration to RegisterServices
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowAnyOrigin");

app.UseSwagger();
app.UseSwaggerUI();  


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
