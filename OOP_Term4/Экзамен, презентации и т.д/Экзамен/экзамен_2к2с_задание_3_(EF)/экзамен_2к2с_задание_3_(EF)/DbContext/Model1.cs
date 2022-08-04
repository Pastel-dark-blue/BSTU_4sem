using System.Data.Entity;

namespace DbCon
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DbContext")
        {
        }

        public virtual DbSet<Good> Good { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<TypesEnum> TypesEnum { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Good>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.Photo)
                .IsUnicode(false);

            modelBuilder.Entity<Organization>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Good)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.ManufacturerId);

            modelBuilder.Entity<TypesEnum>()
                .HasMany(e => e.Good)
                .WithOptional(e => e.TypesEnum)
                .HasForeignKey(e => e.Type);
        }
    }
}
