using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using tech.project.Repository;

namespace tech.project.Controllers
{
  public partial class TrainingsApi : ApiController
  {
    public class EmployeeTrainingsRepository : EmployeeTrainingsAbstractRepository
    {
      [ThreadStatic]
      private readonly Lazy<Model> _model = null;

      public override Model Model
      {
        get {
          return _model.Value;
        }
      }

      /// <summary>
      /// ctor
      /// </summary>
      /// <param name="model">
      ///   thread-local safe  
      /// </param>
      public EmployeeTrainingsRepository( Model model = null )
      {
        _model = model == null ? new Lazy<Model>(() => Activator.CreateInstance<Model>()): new Lazy<Model>(() => model);
      }        
        
      /// <summary>
      ///  All repository data
      /// </summary>
      /// <returns> IEnumerable of EmployeeTraining </returns>
      public override IEnumerable<EmployeeTraining> GetEmployeeTrainings()
      {
        IEnumerable<EmployeeTraining> trainings = null;

        Using<Model>(Model.Database.BeginTransaction(), async ( model ) => {
          Model.ChangeTracker.DetectChanges();
          await Model.SaveChangesAsync();

        //using local-only, with overriden persistence layer...
          trainings = Model.EmployeeTrainings.Local.AsEnumerable();
        });
               
        return trainings;
      }

      public override IEnumerable<EmployeeTraining> GetLatestEmployeeTrainings() {
        List<Employee> groups = Model.EmployeeTrainings.Local.Select(x => x.Employee).Distinct().ToList();
        return groups.Select(x => LastTraining(x));
      }
      
      public override EmployeeTraining LastTraining(Employee e)
      {
        if (Model.Employees.Any(x=>x.Id == e.Id))
        {
          return Model.EmployeeTrainings.Local.OrderByDescending(x => x.AttendDate).LastOrDefault();
        }

        return null;
      }

      public override DateTime? LastTrainingDate(Employee employee )
      {
        return LastTraining(employee)?.AttendDate;
      }

    }
  }

}