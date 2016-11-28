using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.project.tests.conventions;
using System.Data.Entity;


namespace tech.project.tests
{

  using Model = tech.project.tests.conventions;

  [TestFixture]
  [Description("Persistence test for convention-build context")]
  public class EmployeeTrainingContextTests
  {

    [TestFixtureSetUp]
    public void Setup()
    {
      Database.SetInitializer<conventions.Model>(new DropCreateDatabaseAlways<conventions.Model>());
    }

    [Test]
    public void ShouldBeAbleToInitializeAndPersistTheModel()
    {
      var model = new conventions.Model();

      Assert.That(model != null);

      var employee = 
        new conventions.Employee() {
           Id = Guid.NewGuid(),
           Name = "Guid",
           Surname = "Hash",
          Birthdate = DateTime.Parse("01/01/1999")
        };

      model.Employees.Add(employee);

      Assert.DoesNotThrow(() =>
      {
        model.ChangeTracker.DetectChanges(); model.SaveChanges();
      });

      Assert.That(model.Employees.Count() > 0);

      model.Dispose();
    }

  }
}
