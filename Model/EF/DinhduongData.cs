namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DinhduongData : DbContext
    {
        public DinhduongData()
            : base("name=DinhduongData")
        {
        }

        public virtual DbSet<about> abouts { get; set; }
        public virtual DbSet<Congcu> Congcus { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Kieunguoi> Kieunguois { get; set; }
        public virtual DbSet<Loaithucpham> Loaithucphams { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<MuctieuNguoidung> MuctieuNguoidungs { get; set; }
        public virtual DbSet<Nguoidung> Nguoidungs { get; set; }
        public virtual DbSet<Quanly> Quanlies { get; set; }
        public virtual DbSet<Sex> Sexes { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Sobuatrongngay> Sobuatrongngays { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Theodoibuaan> Theodoibuaans { get; set; }
        public virtual DbSet<Thucpham> Thucphams { get; set; }
        public virtual DbSet<Thucpham_tag> Thucpham_tag { get; set; }
        public virtual DbSet<Tintuc> Tintucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<about>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Congcu>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Loaithucpham>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Gioitinh)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Matkhauxacnhan)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.CaloriesTrongngay)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Quanly>()
                .Property(e => e.Taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Quanly>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<Quanly>()
                .Property(e => e.Matkhauxacnhan)
                .IsUnicode(false);

            modelBuilder.Entity<Quanly>()
                .Property(e => e.Hoten)
                .IsUnicode(false);

            modelBuilder.Entity<Quanly>()
                .Property(e => e.Diachi)
                .IsUnicode(false);

            modelBuilder.Entity<Quanly>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Quanly>()
                .Property(e => e.Quyen)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.ID_Tag)
                .IsUnicode(false);

            modelBuilder.Entity<Theodoibuaan>()
                .Property(e => e.Total_calos)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Thucpham>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Thucpham_tag>()
                .Property(e => e.ID_Tag)
                .IsUnicode(false);
        }
    }
}
