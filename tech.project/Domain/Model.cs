namespace tech.project
{
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class Model : DbContext
  {

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
    public virtual DbSet<Training> Trainings { get; set; }

    protected override void OnModelCreating( DbModelBuilder modelBuilder )
    {
      modelBuilder.Entity<Employee>().HasKey<Guid>(x => x.Id).ToTable("Employee");
      modelBuilder.Entity<Training>().HasKey<Guid>(x => x.Id).ToTable("Training");

      modelBuilder.Entity<EmployeeTraining>().HasKey<Guid>(x => x.Id);

    }

  }
}
