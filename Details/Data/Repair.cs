namespace Details.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Repair")]
    public partial class Repair
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; }

        public string Remark { get; set; }

        public int MachineId { get; set; }

        public int TypeRepairId { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Machine Machine { get; set; }

        public virtual TypeRepair TypeRepair { get; set; }
    }
}
