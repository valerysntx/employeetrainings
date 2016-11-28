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

    // Employee
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public partial class Employee
    {
        public System.Guid Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public string Surname { get; set; } // Surname
        public System.DateTime Birthdate { get; set; } // Birthdate

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<EmployeeTraining> EmployeeTrainings { get; set; } // EmployeeTraining.FK_EmployeeTraining_ToEmployee

        public Employee()
        {
            EmployeeTrainings = new System.Collections.ObjectModel.ObservableCollection<EmployeeTraining>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
