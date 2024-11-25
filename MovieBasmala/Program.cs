using Microsoft.EntityFrameworkCore;
using MovieBasmala;
using MovieBasmala.Repos.CategoryRepos;
using MovieBasmala.Repos.DirectorRepos;
using MovieBasmala.Repos.MoviesRepos;
using MovieBasmala.Repos.NationalityRepos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection")));
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<INationalityRepo, NationalityRepo>();
builder.Services.AddScoped<IDirectorRepo,DirectorRepo>();
builder.Services.AddScoped<IMovieRepo, MovieRepo>();
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
