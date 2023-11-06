using System.Text;
using System.Text.Json.Serialization;
using Family.Db;
using Family.Logic.WebService.ChildService;
using Family.Logic.WebService.GenusService;
using Family.Logic.WebService.ParentService;
using Family.Web.Utilities;
using Family.WebDb.WebRepository.ChildRepository;
using Family.WebDb.WebRepository.GenusRepository;
using Family.WebDb.WebRepository.ParentRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddScoped<IParentRepository, ParentRepository>();
builder.Services.AddScoped<IChildService, ChildService>();
builder.Services.AddScoped<IChildRepository, ChildRepository>();
builder.Services.AddScoped<IGenusService, GenusService>();
builder.Services.AddScoped<IGenusRepository, GenusRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;

        var secretKey = builder.Configuration["SecretKey"];

        var secret = Encoding.UTF8.GetBytes(secretKey);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secret)
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("devCors", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyHeader();
    });
});

builder.Services.AddDbContext<FamilyContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Family");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors("devCors");
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();