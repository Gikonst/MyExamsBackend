using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyExamsBackend.Domain;
using MyExamsBackend.Services;
using MyExamsBackend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer()
.AddSwaggerGen()
.AddScoped<IProgrammingLanguagesService, ProgrammingLanguagesService>()
.AddScoped<IExamsService, ExamsService>()
.AddScoped<ICertificatesService, CertificatesService>()
.AddScoped<IAnswersService, AnswersService>()
.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

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
