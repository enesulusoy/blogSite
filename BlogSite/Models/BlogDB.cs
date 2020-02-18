namespace BlogSite.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogDB : DbContext
    {
        public BlogDB()
            : base("name=BlogDB")
        {
        }

        public virtual DbSet<Etiket> Etikets { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Makale> Makales { get; set; }
        public virtual DbSet<Yetki> Yetkis { get; set; }
        public virtual DbSet<Yorum> Yorums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.Makales)
                .WithMany(e => e.Etikets)
                .Map(m => m.ToTable("EtiketMakale").MapLeftKey("EtiketId").MapRightKey("MakaleId"));

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Makales)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Makales)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);
        }
    }
}
