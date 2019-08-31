using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace onlineshop.Models
{
    public partial class myshopContext : DbContext
    {
        public myshopContext(DbContextOptions<myshopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adminlogin>(entity =>
            {
                entity.HasKey(e => e.Adminid)
                    .HasName("PK__Adminlog__719EE0908294CED6");

                entity.Property(e => e.Adminid).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);
            });









            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

              
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.Total)
                   .HasColumnName("total")
                   .HasMaxLength(50);


                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_cart_customer");

               
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerAdd)
                    .HasColumnName("customer_add")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerDob)
                    .HasColumnName("customer_dob")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerEmail)
                    .HasColumnName("customer_email")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerFull)
                    .HasColumnName("customer_full")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerHint)
                    .HasColumnName("customer_hint")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerPass)
                    .HasColumnName("customer_pass")
                    .HasMaxLength(50);
                 
                

               });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_order_customer");
            });

            modelBuilder.Entity<Orderitems>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__orderite__52020FDDFBE92BD7");

                entity.ToTable("orderitems");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(50);

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_orderitems_cart");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_orderitems_order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_orderitems_products");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("products");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Brand)
                    .HasColumnName("brand")
                    .HasMaxLength(50);

                entity.Property(e => e.Categories)
                    .HasColumnName("categories")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductDisc)
                    .HasColumnName("product_disc")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductImg1)
                    .HasColumnName("product_img1")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductImg2)
                    .HasColumnName("product_img2")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductImg3)
                    .HasColumnName("product_img3")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.Property(e => e.ProductQty).HasColumnName("product_qty");

                entity.Property(e => e.ProductTitle)
                    .HasColumnName("product_title")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });
            modelBuilder.Entity<SizeColor>(entity =>
            {
                entity.HasKey(e => e.ScId)
                    .HasName("PK__size_col__C403E19671E7CA83");

                entity.ToTable("size_color");

                entity.Property(e => e.ScId).HasColumnName("SC_id");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductId).HasColumnName("product_id");


                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasMaxLength(50);

               
            });
        }
        public virtual DbSet<Adminlogin> Adminlogin { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Orderitems> Orderitems { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<SizeColor> SizeColor { get; set; }
    }
}