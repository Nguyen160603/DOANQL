using System;
using System.Collections.Generic;
using DOANQL.Models;
using Microsoft.EntityFrameworkCore;
using DOANQL.Areas.Admin.Models;



namespace DOANQL.Models
{
    public partial class AlskContext : DbContext
    {
        public AlskContext()
        {
        }

        public AlskContext(DbContextOptions<AlskContext> options)
            : base(options)
        {
        }


        public virtual DbSet<TbBlog> TbBlogs { get; set; }

        public virtual DbSet<TbBlogComment> TbBlogComments { get; set; }

        public virtual DbSet<TbCategory> TbCategorys { get; set; }

        public virtual DbSet<TbContact> TbContacts { get; set; }


        public virtual DbSet<TbMenu> TbMenus { get; set; }



        public virtual DbSet<TbRoom> TbRooms { get; set; }

        public virtual DbSet<TbRooomCategory> TbRoomCategories { get; set; }

        public virtual DbSet<AdminMenu> AdminMenus { get; set; }
        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseSqlServer("data source=DESKTOP-IV0MTE3\\SQLEXPRESS;initial catalog=Harmic;integrated security=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            modelBuilder.Entity<TbBlog>(entity =>
            {
                entity.HasKey(e => e.BlogId).HasName("PK_tb_Post");

                entity.ToTable("tb_Blog");

                entity.Property(e => e.Alias).HasMaxLength(250);
                entity.Property(e => e.CreatedBy).HasMaxLength(150);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(4000);
                entity.Property(e => e.Image).HasMaxLength(500);
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedBy).HasMaxLength(150);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.SeoDescription).HasMaxLength(500);
                entity.Property(e => e.SeoKeywords).HasMaxLength(250);
                entity.Property(e => e.SeoTitle).HasMaxLength(250);
                entity.Property(e => e.Title).HasMaxLength(250);



                entity.HasOne(d => d.Category).WithMany(p => p.TbBlogs)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_tb_Post_tb_Category");
            });

            modelBuilder.Entity<TbBlogComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("tb_BlogComment");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Detail).HasMaxLength(200);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);


                entity.HasOne(d => d.Blog).WithMany(p => p.TbBlogComments)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_tb_BlogComment_tb_Blog");
            });

            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK_tb_Menu");

                entity.ToTable("tb_Category");

                entity.Property(e => e.Alias).HasMaxLength(150);
                entity.Property(e => e.CreatedBy).HasMaxLength(150);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.ModifiedBy).HasMaxLength(150);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.SeoDescription).HasMaxLength(500);
                entity.Property(e => e.SeoKeywords).HasMaxLength(250);
                entity.Property(e => e.SeoTitle).HasMaxLength(250);
                entity.Property(e => e.Title).HasMaxLength(150);
            });

            modelBuilder.Entity<TbContact>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("tb_Contact");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Email).HasMaxLength(150);
                entity.Property(e => e.ModifiedBy).HasMaxLength(150);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.Phone).HasMaxLength(50);
            });




            modelBuilder.Entity<TbMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId).HasName("PK_tb_Menu_1");

                entity.ToTable("tb_Menu");

                entity.Property(e => e.Alias).HasMaxLength(150);
                entity.Property(e => e.CreatedBy).HasMaxLength(150);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedBy).HasMaxLength(150);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Title).HasMaxLength(150);
            });
            modelBuilder.Entity<TbRoom>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.ToTable("tb_Room");

                entity.Property(e => e.Alias).HasMaxLength(250);
                entity.Property(e => e.CreatedBy).HasMaxLength(150);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(4000);
                entity.Property(e => e.Image).HasMaxLength(500);
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedBy).HasMaxLength(150);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.CategoryRoom).WithMany(p => p.TbRooms)
                    .HasForeignKey(d => d.CategoryRoomId)
                    .HasConstraintName("FK_tb_Product_db_CategoryProduct");
            });

            modelBuilder.Entity<TbRooomCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryRoomId).HasName("PK_db_Category");

                entity.ToTable("tb_RoomCategory");

                entity.Property(e => e.Alias).HasMaxLength(150);
                entity.Property(e => e.CreatedBy).HasMaxLength(150);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Icon).HasMaxLength(500);
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedBy).HasMaxLength(150);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Title).HasMaxLength(150);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
