namespace Details.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeMachine")]
    public partial class TypeMachine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeMachine()
        {
            Machines = new HashSet<Machine>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateRelease { get; set; }

        [Required]
        [StringLength(50)]
        public string Stamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Machine> Machines { get; set; }
    }
}
