using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<AppDbContext>();

app.MapGet("/v1/todos", (AppDbContext context) =>
{
    var todos = context.Todos;
    return Results.Ok(todos);
});

app.Run();

public record Todo(Guid Id, string Title, bool Done);

public class AppDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource=app.db;Cache=Shared");
}