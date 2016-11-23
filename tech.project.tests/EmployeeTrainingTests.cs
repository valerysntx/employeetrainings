using System;
using NUnit.Framework;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace tech.project.tests
{
  [TestFixture]
  public class EmployeeTrainingTests
  {
    [Test]
    public void ShouldCreateEmployeeInstance()
    {
      Assert.Catch<Exception>(() => new Training());
    }

    [Test]
    public void ShouldCreateTrainingInstance()
    {

    }

    static Model Model { get; set; }

    [TestFixtureSetUp]
    void SetupModel()
    {
      Model = new Model();
      if (! Model.Database.Exists())
      {
        Model.Database.CreateIfNotExists();
        Model.Employees.AddRange(new[] {
         new Employee {
            Id = Guid.NewGuid(),
            Birthdate = DateTime.Parse("08/21/1981"),
            Name = "Valery",
            Surname = "Schepaschenko"
          },

        new Employee {
          Id = Guid.NewGuid(),
          Birthdate = DateTime.Parse("12/06/1986"),
          Name = "Name", Surname = "Surname"
        }
      });

     }
      

     Model.SaveChanges();

   }

    [Test]
    public void SelectEachEmployeeTrainings()
    {

      var model = new Model();
      Assert.NotNull(model);


    }

    public class TrainingVisit: EmployeeTraining
    {

    }

    public IEnumerable<TrainingVisit> GetLatestTrainings(Employee employee )
    {
      return Model.EmployeeTrainings.AsQueryable()
                    .Select(t => new TrainingVisit
                    {
                      AttendDate = t.AttendDate,
                      Employee = t.Employee,
                      Training = t.Training
                    }).Distinct();

    }



  }
}