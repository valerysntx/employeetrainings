namespace tech.project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeTraining")]
    public partial class EmployeeTraining
    {
        public Guid Id { get; set; }

        public Employee Employee { get; set; }

        public Training Training { get; set; }

        public DateTime AttendDate { get; set; }
    }
}
