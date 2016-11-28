using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Http;

namespace tech.project.Controllers
{

  [AllowAnonymous]
  public partial class TrainingsApi : ApiController
  {
    static readonly EmployeeTrainingsRepository repository = new EmployeeTrainingsRepository();
 
    [HttpGet]
    [Route("/EmployeeTraining")]
    public async Task<IEnumerable<EmployeeTraining>> EmployeeTraining(string employeeName)
    {
      return await Task.FromResult(
        repository.GetEmployeeTrainings().Where(
          e => e.Employee.Name.ToLowerInvariant().Contains(employeeName.ToLowerInvariant()))
                                    ).ConfigureAwait(false);
    }

  }
}