using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TasksDB"));
//builder.Services.AddSqlServer<TaskContext>("Data Source=L03514531L01\\SQLEXPRESS;Initial Catalog=TasksDB;user id=TEC\\L03514531;password='';Trusted_Connection=True; Integrated Security=True");

builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("CnTasks"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/dbconnection", async ([FromServices] TaskContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tasks", async ([FromServices] TaskContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks);
    //return Results.Ok(dbContext.Tasks.Include(task => task.Category).Where(task => task.PriorityTask == Priority.Low));
});

app.MapPost("/api/tasks", async ([FromServices] TaskContext dbContext, [FromBody] WebApplication1.Models.Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.Created = DateTime.UtcNow;
    await dbContext.AddAsync(task);
    //await dbContext.Tasks.AddAsync(task);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tasks/{id}", async ([FromServices] TaskContext dbContext, [FromBody] WebApplication1.Models.Task task, [FromRoute] Guid id) =>
{

    WebApplication1.Models.Task currentTask = dbContext.Tasks.Find(id);

    if(currentTask != null)
    {
        currentTask.CategoryId = task.CategoryId;
        currentTask.Title = task.Title;
        currentTask.PriorityTask = task.PriorityTask;
        currentTask.Description = task.Description;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    
    return Results.NotFound();


});

app.MapDelete("/api/tasks/{id}", async ([FromServices] TaskContext dbContext, [FromRoute] Guid id) =>
{

    WebApplication1.Models.Task currentTask = dbContext.Tasks.Find(id);

    if (currentTask != null)
    {
        dbContext.Remove(currentTask);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();


});



app.Run();
