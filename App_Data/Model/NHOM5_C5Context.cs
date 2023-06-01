using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class NHOM5_C5Context : DbContext
    {
        public NHOM5_C5Context() 
        { 
        }
        public NHOM5_C5Context(DbContextOptions<NHOM5_C5Context> options)
            : base(options)
        {

        }

        public virtual DbSet<Bill> Bills { get; set; } 
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Cart> Carts { get; set; } 
        public virtual DbSet<CartDetail> CartDetails { get; set; } 
        public virtual DbSet<ChiTietTichDiem> ChiTietTichDiems { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; } 
        public virtual DbSet<Color> Colors { get; set; } 
        public virtual DbSet<KhachHang> KhachHangs { get; set; } 
        public virtual DbSet<NhanVien> NhanViens { get; set; } 
        public virtual DbSet<Product> Products { get; set; } 
        public virtual DbSet<ProductDetail> ProductDetails { get; set; } 
        public virtual DbSet<Size> Sizes { get; set; } 
        public virtual DbSet<TichDiem> TichDiems { get; set; } 
        public virtual DbSet<UuDaiTichDiem> UuDaiTichDiems { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; } 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LUONG2003\GIACATLUONG;Initial Catalog=Nhom5_C5_CodeFirst;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
