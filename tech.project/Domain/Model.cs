namespace tech.project
{
  using System.Data.Entity;
  using System.Threading;
  using System.Threading.Tasks;

  public partial class Model : DbContext
  {

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
    public virtual DbSet<Training> Trainings { get; set; }

    protected override void OnModelCreating( DbModelBuilder modelBuilder )
    {
      Database.SetInitializer(new DropCreateDatabaseAlways<Model>());

      modelBuilder.Entity<Training>().HasKey(x=>x.Id);
      modelBuilder.Entity<Employee>().HasKey(x => x.Id);

      modelBuilder.Entity<EmployeeTraining>().HasRequired(x => x.Employee);
      modelBuilder.Entity<EmployeeTraining>().HasRequired(x => x.Training);
    }

    #region ! Overriden Persistence

    public override int SaveChanges()
    {
      return 0;
    }
    public override Task<int> SaveChangesAsync( CancellationToken cancellationToken )
    {
      return Task.FromResult(0);
    }
    
    #endregion

  }
}
