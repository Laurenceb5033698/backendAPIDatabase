var demoFrontend = "_myDemoFrontend";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: demoFrontend,
    policy =>
    {
        policy.WithOrigins("http://localhost:5026");
        policy.AllowAnyHeader();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//enable CORS
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
