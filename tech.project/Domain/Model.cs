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
    }

  }
}
