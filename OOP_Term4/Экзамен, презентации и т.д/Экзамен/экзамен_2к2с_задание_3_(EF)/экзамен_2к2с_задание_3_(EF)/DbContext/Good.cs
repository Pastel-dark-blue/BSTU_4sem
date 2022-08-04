namespace DbCon
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Good")]
    public partial class Good
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double? Width_cm { get; set; }

        public double? Height_cm { get; set; }

        public double? Length_cm { get; set; }

        public double? Weight_kg { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        public DateTime? Date { get; set; }

        public int? Amount { get; set; }

        [Column("Price_$")]
        public double? Price__ { get; set; }

        public int? ManufacturerId { get; set; }

        public string Photo { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual TypesEnum TypesEnum { get; set; }
    }
}
