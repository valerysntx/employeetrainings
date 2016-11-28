using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static tech.project.Controllers.TrainingsApi;

namespace tech.project.tests
{
  [TestFixture]
  [Description("local mem-context model + repository tests")]
  public class EmployeeTrainingTests
  {
    static Model Model { get; set; }

    [Test]
    public void ShouldCreateEmployeeInstance()
    {
      Assert.NotNull(new Employee() { Id = Guid.NewGuid(), Name = "Employee", Surname = "sdfgsfdg" ,Birthdate = DateTime.Parse("01/01/1980")});
    }

    [Test]
    public void ShouldCreateTrainingInstance()
    {
      Assert.NotNull(new Training() { Id = Guid.NewGuid(), Name = "Juniors!", Description = "Train Juniors" } );
    }

    public Model InitializeModel()
    {
      Model = new Model();

      Model.Employees.Add(
        new Employee {
            Id = Guid.NewGuid(),
            Birthdate = DateTime.Parse("08/21/1981"),
            Name = "Valery",
            Surname = "Schepaschenko"
      });

      Model.Employees.Add(
        new Employee
        {
          Id = Guid.NewGuid(),
          Birthdate = DateTime.Parse("08/01/1988"),
          Name = "Name",
          Surname = "Surname"
        });

      return Model;

     }
     
    [Test]
    public void ShouldCreateModel()
    {
      Assert.NotNull(InitializeModel());
    }

    [Test]
    [Description("As soon the model was overriden - see false-positive results for such test")]
    public void CouldPersistTheModel()
    {
      var model = InitializeModel();
      Assert.NotNull(model);
      Assert.DoesNotThrow(() => model.SaveChanges());
    }

    
    [Test]
    public void ShouldBeAbleToGetAllTrainingsFromRepository()
    {
      Model model = InitializeModel();
      var repository = new EmployeeTrainingsRepository(model);

      Assert.NotNull(repository);

      Employee employee = model.Employees.Local.FirstOrDefault();
      Assert.NotNull(employee);

      var training = new Training { Id = Guid.NewGuid(), Name = "Empty room training", Description = "Anybody ?" };
      model.EmployeeTrainings.AddRange(
       new[] {
        new EmployeeTraining
        {
          Id = Guid.NewGuid(),
          AttendDate = DateTime.Now,
          Training = training,
          Employee = employee
        },

        new EmployeeTraining
        {
          Id = Guid.NewGuid(),
          AttendDate = DateTime.Now + TimeSpan.FromHours(-1),
          Training = training,
          Employee = employee

        }}
       );

      Assert.DoesNotThrow(() => {
        Assert.That(repository.GetEmployeeTrainings().Count() == 2);
      });
  
    }

    [Test]
    public void ShouldAttendTheTrainingTest()
    {
      var model = InitializeModel();
      Assert.NotNull(model);

      var employee = model.Employees.FirstOrDefault();

      model.EmployeeTrainings.Add(
        new EmployeeTraining
        {
          Id = Guid.NewGuid(),
          AttendDate = DateTime.Now,
          Training = new Training { Id = Guid.NewGuid(), Name = "Empty room training", Description = "Anybody ?" },
          Employee = employee
        });

      Assert.That(model.EmployeeTrainings.Local.Any());
    }

    [Test]
    public void ShouldAttendTheTrainingTwiceTest()
    {
      var model = InitializeModel();
      Assert.NotNull(model);
      var employee = model.Employees.FirstOrDefault();

      var training = new Training { Id = Guid.NewGuid(), Name = "Empty room training", Description = "Anybody ?" };
      model.EmployeeTrainings.AddRange(
       new[] {
        new EmployeeTraining
        {
          Id = Guid.NewGuid(),
          AttendDate = DateTime.Now,
          Training = training,
          Employee = employee
        },

        new EmployeeTraining
        {
          Id = Guid.NewGuid(),
          AttendDate = DateTime.Now + TimeSpan.FromHours(-1),
          Training = training,
          Employee = employee

        }}
       );
 
      Assert.True(model.EmployeeTrainings.Local.Count() == 2);

    }

    public class TrainingVisit: EmployeeTraining
    {

    }

    public IEnumerable<TrainingVisit> GetLatestTrainings(Employee employee )
    {
      return Model.EmployeeTrainings.AsQueryable()
                    .Where(x=> x.Employee.Id == employee.Id)
                    .Select(t => new TrainingVisit
                    {
                      AttendDate = t.AttendDate,
                      Employee = t.Employee,
                      Training = t.Training
                    }).Distinct();
    }

    [Test]
    public void ShouldCreateEmployeeTrainingsRepository()
    {
      Assert.That(new EmployeeTrainingsRepository( InitializeModel() ) != null);
    }



  }
}