using Microsoft.EntityFrameworkCore;

namespace Tasks;

public class PupleTeacherContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Many-to-Many Fluent API
        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Pupils)
            .WithMany(p => p.Teachers);
    }
    
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Pupil> Pupils { get; set; }
}