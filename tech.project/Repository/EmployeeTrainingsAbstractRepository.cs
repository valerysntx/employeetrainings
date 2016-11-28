using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace tech.project.Repository
{
  /// <summary>
  /// EmployeeTrainings Repository
  /// </summary>
  public abstract class EmployeeTrainingsAbstractRepository : IRepository<Model>
  {
    public abstract Model Model { get; }
    public IEnumerable<EmployeeTraining> All()
    {
      return Model.EmployeeTrainings.Local.AsEnumerable();
    }

    protected void Using<T>( IDisposable lockOn, Action<T> actionOnModel ) where T : Model
    {
      using (lockOn) actionOnModel((T) Model);
    }

    public void Save()
    {
      Model.SaveChanges();
    }


    public abstract IEnumerable<EmployeeTraining> GetEmployeeTrainings();
    public abstract IEnumerable<EmployeeTraining> GetLatestEmployeeTrainings();
    public abstract EmployeeTraining LastTraining( Employee employee );
    public abstract DateTime? LastTrainingDate( Employee employee );
  }
}