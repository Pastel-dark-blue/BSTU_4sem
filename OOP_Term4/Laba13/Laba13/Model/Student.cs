namespace Laba13.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            StudSub = new HashSet<StudSub>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Fio { get; set; }

        [StringLength(200)]
        public string Faculty { get; set; }

        [StringLength(200)]
        public string Spec { get; set; }

        public int? Group_ { get; set; }

        public int? Subgroup { get; set; }

        public int? Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudSub> StudSub { get; set; }
    }
}
