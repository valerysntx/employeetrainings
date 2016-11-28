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

    // Training
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public partial class TrainingConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Training>
    {
        public TrainingConfiguration()
            : this("dbo")
        {
        }

        public TrainingConfiguration(string schema)
        {
            ToTable("Training", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName(@"Name").IsRequired().HasColumnType("nvarchar(max)");
            Property(x => x.Description).HasColumnName(@"Description").IsRequired().HasColumnType("nvarchar(max)");
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
