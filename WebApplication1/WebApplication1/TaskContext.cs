using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1;


public class TaskContext: DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Models.Task> Tasks { get; set; }

    public TaskContext(DbContextOptions<TaskContext> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        List<Category> categoryInit = new List<Category>();
        categoryInit.Add(new Category() { CategoryId = Guid.Parse("4c9a5ea0-4158-41d8-871e-32e4737343ad"), CategoryName = "Work activities", CategorySize = 1 });
        categoryInit.Add(new Category() { CategoryId = Guid.Parse("4c9a5ea0-4158-41d8-871e-32e473734302"), CategoryName = "Personal activities", CategorySize = 1 });

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);
            category.Property(p => p.CategoryName).IsRequired().HasMaxLength(150);
            category.Property(p => p.CategoryDescription).IsRequired(false);
            category.Property(p => p.CategorySize);

            category.HasData(categoryInit);
        });

        List<Models.Task> taskInit = new List<Models.Task>();
        taskInit.Add(new Models.Task() { TaskId = Guid.Parse("4c9a5ea0-4158-41d8-871e-32e473734310"), CategoryId = Guid.Parse("4c9a5ea0-4158-41d8-871e-32e4737343ad"), PriorityTask = Priority.Medium, Title = "Do the screen 1", Created = DateTime.Now });

        taskInit.Add(new Models.Task() { TaskId = Guid.Parse("4c9a5ea0-4158-41d8-871e-32e473734311"), CategoryId = Guid.Parse("4c9a5ea0-4158-41d8-871e-32e473734302"), PriorityTask = Priority.Low, Title = "Watch Netflix", Created = DateTime.Now });

        modelBuilder.Entity<Models.Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(p => p.TaskId);
            task.HasOne(t => t.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description).IsRequired(false);
            task.Property(p => p.PriorityTask);
            task.Property(p => p.Created);
            task.Ignore(p => p.Resume);

            task.HasData(taskInit);
        });
    }
}

