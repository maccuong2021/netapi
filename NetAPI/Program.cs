var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*
 * dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p 1234
   dotnet dev-certs https --trust
   docker compose up
   dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p 123456
   dotnet dev-certs https --trust
 */
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
