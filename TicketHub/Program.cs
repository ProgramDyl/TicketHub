var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/////////////////////////////
///   CORS Configuration  //
/////////////////////////////
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactFrontend",
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:3000",
                "https://proud-smoke-0828fe90f.6.azurestaticapps.net/") 
              .AllowAnyHeader()
              .AllowAnyMethod();
        });
});


var app = builder.Build();

//user secrets
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// connection string for cors
app.UseCors("AllowAzureStaticWebApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
