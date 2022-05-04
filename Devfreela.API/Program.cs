using Devfreela.API.Filter;
using Devfreela.Aplication.Extensions;
using DevFreela.Shared.Models.UI;

const string SETTINGS = "Settings";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(filterType: typeof(ValidationFilter));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddInjectionDependecies(builder.Configuration);
builder.Services.AddMediatDependencies();
builder.Services.AddValidation();
builder.Services.ConfigureJwt(builder.Configuration.GetSection(SETTINGS).Get<ApiSettings>());

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
