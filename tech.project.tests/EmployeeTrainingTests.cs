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
      Assert.NotNull(new Employee() { Id = Guid.NewGuid(), Name = "Employee", Surname = "sdfgsfdg" ,Birthdate = DateTime.Parse("01/01/1980")});
    }

    [Test]
    public void ShouldCreateTrainingInstance()
    {
      Assert.NotNull(new Training() { Id = Guid.NewGuid(), Name = "Juniors!", Description = "Train Juniors" } );
    }

    static Model Model { get; set; }


    public Model InitializeModel()
    {
      Model = new Model();
      
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

      return Model;
     }
     
    [Test]
    public void ShouldCreateModel()
    {
      var model = InitializeModel();
      Assert.NotNull(model);
    }

    [Test]
    public void CouldPersistTheModel()
    {
      var model = InitializeModel();
      Assert.NotNull(model);
      model.SaveChanges();
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



  }
}