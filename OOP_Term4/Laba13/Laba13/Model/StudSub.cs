namespace Laba13.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudSub")]
    public partial class StudSub
    {
        public int Id { get; set; }

        public int? StudId { get; set; }

        public int? SubId { get; set; }

        public int? Mark { get; set; }

        public int? MissedHours { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
