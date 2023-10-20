using Family.Db;
using Family.Web.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("devCors", policyBuilder =>
    {
        policyBuilder .AllowAnyOrigin();
        policyBuilder .AllowAnyMethod();
        policyBuilder .AllowAnyHeader();
    });
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
app.UseAuthentication();

app.MapControllers();

app.Run();
