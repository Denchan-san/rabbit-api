using Microsoft.EntityFrameworkCore;
using Rabbit_API;
using Rabbit_API.Data;
using Rabbit_API.Repository;
using Rabbit_API.Repository.IRepository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//sql
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
//identity

//Repository
builder.Services.AddScoped<IThreadRepository, ThreadRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentaryRepository, CommentaryRepository>();
//Automapper
builder.Services.AddAutoMapper(typeof(MappingConfig));


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

app.UseAuthorization();

app.MapControllers();

app.Run();
