using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyExamsBackend.Domain;
using MyExamsBackend.Services;
using MyExamsBackend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProgrammingLanguagesService, ProgrammingLanguagesService>();
builder.Services.AddScoped<IQuestionsService,QuestionsService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IExamsService, ExamsService>();
builder.Services.AddScoped<ICertificatesService, CertificatesService>();
builder.Services.AddScoped<IAnswersService, AnswersService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
