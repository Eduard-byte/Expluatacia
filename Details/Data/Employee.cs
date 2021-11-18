using System.IO;

namespace Details.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Repairs = new HashSet<Repair>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        public int Age { get; set; }

        public bool IsPaid { get; set; }

        [Required]
        public string ImageUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repair> Repairs { get; set; }


        public string GetStatus
        {
            get
            {
                if (IsPaid)
                    return "Оплачен";

                return "Заявка отменена";
            }
        }

        public string GetColor
        {
            get
            {
                if (IsPaid)
                    return "#C1FFBF";

                return "#FFC3BF";
            }
        }

        public string GetImage
        {
            get
            {
                if (ImageUser is null)
                    return null;
                return Directory.GetCurrentDirectory() + @"\Image\Employee\" + ImageUser;
            }
        }

        public string GetStatusFont
        {
            get
            {
                if (IsPaid)
                    return "Normal";

                return "Bold";
            }
        }
    }
}
