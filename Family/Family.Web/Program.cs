using Family.Db;
using Family.Logic.ChildrenService;
using Family.Logic.GenusService;
using Family.Logic.ParentsService;
using Family.Web.Utilities;
using Family.WebDb.ChildrenRepository;
using Family.WebDb.GenusRepository;
using Family.WebDb.ParentsRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IParentsService, ParentsService>();
builder.Services.AddScoped<IParentsRepository, ParentsRepository>();
builder.Services.AddScoped<IChildrenService, ChildrenService>();
builder.Services.AddScoped<IChildrenRepository, ChildrenRepository>();
builder.Services.AddScoped<IGenusService, GenusService>();
builder.Services.AddScoped<IGenusRepository, GenusRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("devCors", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

builder.Services.AddDbContext<FamilyContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Family");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

using var scope = app.Services.CreateScope();

var context = scope.ServiceProvider.GetService<FamilyContext>();

context!.Database.EnsureCreated();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors("devCors");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();