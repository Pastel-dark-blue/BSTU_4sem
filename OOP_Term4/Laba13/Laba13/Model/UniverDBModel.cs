using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Laba13.Model
{
    public partial class UniverDBModel : DbContext
    {
        public UniverDBModel()
            : base("name=UniverDBModel")
        {
        }

        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudSub> StudSub { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudSub)
                .WithOptional(e => e.Student)
                .HasForeignKey(e => e.StudId);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.StudSub)
                .WithOptional(e => e.Subject)
                .HasForeignKey(e => e.SubId);
        }
    }
}
