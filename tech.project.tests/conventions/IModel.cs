// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

namespace tech.project.tests.conventions
{
    using System.Collections.ObjectModel;

    public partial interface IModel : System.IDisposable
    {
        System.Data.Entity.DbSet<Employee> Employees { get; set; } // Employee
        System.Data.Entity.DbSet<EmployeeTraining> EmployeeTrainings { get; set; } // EmployeeTraining
        System.Data.Entity.DbSet<Training> Trainings { get; set; } // Training

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
    }

}
// </auto-generated>