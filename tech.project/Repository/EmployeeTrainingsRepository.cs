using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace tech.project.Controllers
{
  public partial class TrainingsApi : ApiController
  {
    
    public class EmployeeTrainingsRepository<T> where T : Model, new()
    {
      [ThreadStatic]
      private readonly Lazy<T> _model = null;

      public T Model
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
        _model = model == null ? new Lazy<T>(() => Activator.CreateInstance<T>()): new Lazy<T>(() => (T) model);
      }        
        
      Action Using(IDisposable lockOn, Action<T> actionOnModel)
      {
         using (lockOn) return () => actionOnModel(Model);
      }

      public IEnumerable<EmployeeTraining> GeEmployeeTrainings()
      {
        IEnumerable<EmployeeTraining> result = null;
            Using(Model.Database.BeginTransaction(), async ( model ) =>
            {
              Model.ChangeTracker.DetectChanges();
              await model.SaveChangesAsync();

              result = model.EmployeeTrainings.DistinctBy(x => x.Employee).ToList();
            });

        return result;
      }
    }
  }

}