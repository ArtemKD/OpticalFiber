using StationsService.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy", builder => builder
		.WithOrigins("http://localhost:4200")
		.AllowAnyMethod()
		.AllowAnyHeader()
		.AllowCredentials()
		);
});

builder.Services.AddControllers()
	.AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddMappingProfiles();
builder.Services.AddPostgresContext(builder.Configuration);
builder.Services.AddSheduleService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
