﻿// <auto-generated />
using System;
using App_Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App_Data.Migrations
{
    [DbContext(typeof(NHOM5_C5Context))]
    partial class NHOM5_C5ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App_Data.Model.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChiKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DiaChiShop")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<double>("FreeShip")
                        .HasColumnType("float");

                    b.Property<string>("GiamGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid?>("IdkhachHang")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid?>("IdnhanVien")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid?>("IduuDaiTichDiem")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid?>("Idvoucher")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("NgayThanhToan")
                        .IsRequired()
                        .HasColumnType("Datetime");

                    b.Property<double>("SoTienGiam")
                        .HasColumnType("float");

                    b.Property<double>("TienKhachDua")
                        .HasColumnType("float");

                    b.Property<double>("TienShip")
                        .HasColumnType("float");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.Property<int?>("TrangThai")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdkhachHang");

                    b.HasIndex("IdnhanVien");

                    b.HasIndex("IduuDaiTichDiem");

                    b.HasIndex("Idvoucher");

                    b.ToTable("Hóa Đơn", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.BillDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<Guid?>("Idbill")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid?>("IdproductDetails")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<int?>("SoLuong")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TrangThai")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Idbill");

                    b.HasIndex("IdproductDetails");

                    b.ToTable("Hóa Đơn Chi Tiết", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<Guid?>("IdcartDetails")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid?>("IdkhachHang")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime?>("NgayTao")
                        .IsRequired()
                        .HasColumnType("Datetime");

                    b.Property<int?>("SoLuong")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdcartDetails");

                    b.HasIndex("IdkhachHang");

                    b.ToTable("Giỏ hàng", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.CartDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<Guid?>("IdproductDetails")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<int?>("SoLuong")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdproductDetails");

                    b.ToTable("Giỏ hàng chi tiết", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.ChiTietTichDiem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SoDiemTich")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TrangThai")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Chi Tiết tích điểm", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.ChucVu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Chức vụ", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Màu Sắc", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.KhachHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid?>("IdtichDiem")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("IdtichDiem");

                    b.ToTable("Khách hàng", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.NhanVien", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid?>("IdchucVu")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("Ngaysinh")
                        .IsRequired()
                        .HasColumnType("Datetime");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("IdchucVu");

                    b.ToTable("Nhân viên", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TenSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Sản Phẩm", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.ProductDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BaoHanh")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<string>("CongNgheManHinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DoPhanGiai")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<double>("GiaBan")
                        .HasColumnType("float");

                    b.Property<double>("GiaSale")
                        .HasColumnType("float");

                    b.Property<Guid?>("IdSale")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid?>("Idcolor")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid?>("Idproduct")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid?>("Idsize")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("NgaySanXuat")
                        .IsRequired()
                        .HasColumnType("Datetime");

                    b.Property<string>("NhaSanXuat")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Series")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("SoLuongTon")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("TheLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TrangThaiKhuyenMai")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("IdSale");

                    b.HasIndex("Idcolor");

                    b.HasIndex("Idproduct");

                    b.HasIndex("Idsize");

                    b.ToTable("Sản Phẩm Chi Tiết", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.Sale", b =>
                {
                    b.Property<Guid>("IDSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GiaTriSale")
                        .HasColumnType("int");

                    b.Property<string>("MaSale")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("Datetime");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("Datetime");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IDSale");

                    b.ToTable("Giảm Giá sản phẩm", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Size1")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Kích Cỡ", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.TichDiem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SoDiem")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Tích điểm", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.UuDaiTichDiem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChiTietTichDiemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Idbill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdchiTietTichDiem")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdtichDiem")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime?>("NgayTichDiem")
                        .IsRequired()
                        .HasColumnType("Datetime");

                    b.Property<int?>("SoDiemDung")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TrangThai")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChiTietTichDiemId");

                    b.HasIndex("IdtichDiem");

                    b.ToTable("Ưu đãi tích điểm", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.Voucher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("PhanTramGiam")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TrangThai")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mã giảm giá", (string)null);
                });

            modelBuilder.Entity("App_Data.Model.Bill", b =>
                {
                    b.HasOne("App_Data.Model.KhachHang", "KhachHang")
                        .WithMany("Bills")
                        .HasForeignKey("IdkhachHang");

                    b.HasOne("App_Data.Model.NhanVien", "NhanVien")
                        .WithMany("Bills")
                        .HasForeignKey("IdnhanVien");

                    b.HasOne("App_Data.Model.UuDaiTichDiem", "UuDaiTichDiem")
                        .WithMany("Bills")
                        .HasForeignKey("IduuDaiTichDiem");

                    b.HasOne("App_Data.Model.Voucher", "Voucher")
                        .WithMany("Bills")
                        .HasForeignKey("Idvoucher");

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");

                    b.Navigation("UuDaiTichDiem");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("App_Data.Model.BillDetail", b =>
                {
                    b.HasOne("App_Data.Model.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("Idbill");

                    b.HasOne("App_Data.Model.ProductDetail", "ProductDetail")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdproductDetails");

                    b.Navigation("Bill");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("App_Data.Model.Cart", b =>
                {
                    b.HasOne("App_Data.Model.CartDetail", "CartDetail")
                        .WithMany("Carts")
                        .HasForeignKey("IdcartDetails");

                    b.HasOne("App_Data.Model.KhachHang", "KhachHang")
                        .WithMany("Carts")
                        .HasForeignKey("IdkhachHang");

                    b.Navigation("CartDetail");

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("App_Data.Model.CartDetail", b =>
                {
                    b.HasOne("App_Data.Model.ProductDetail", "ProductDetail")
                        .WithMany("CartDetails")
                        .HasForeignKey("IdproductDetails");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("App_Data.Model.KhachHang", b =>
                {
                    b.HasOne("App_Data.Model.TichDiem", "TichDiem")
                        .WithMany("KhachHangs")
                        .HasForeignKey("IdtichDiem");

                    b.Navigation("TichDiem");
                });

            modelBuilder.Entity("App_Data.Model.NhanVien", b =>
                {
                    b.HasOne("App_Data.Model.ChucVu", "ChucVu")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdchucVu");

                    b.Navigation("ChucVu");
                });

            modelBuilder.Entity("App_Data.Model.ProductDetail", b =>
                {
                    b.HasOne("App_Data.Model.Sale", "Sale")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IdSale");

                    b.HasOne("App_Data.Model.Color", "Color")
                        .WithMany("ProductDetails")
                        .HasForeignKey("Idcolor");

                    b.HasOne("App_Data.Model.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("Idproduct");

                    b.HasOne("App_Data.Model.Size", "Size")
                        .WithMany("ProductDetails")
                        .HasForeignKey("Idsize");

                    b.Navigation("Color");

                    b.Navigation("Product");

                    b.Navigation("Sale");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("App_Data.Model.UuDaiTichDiem", b =>
                {
                    b.HasOne("App_Data.Model.ChiTietTichDiem", "ChiTietTichDiem")
                        .WithMany("UuDaiTichDiems")
                        .HasForeignKey("ChiTietTichDiemId");

                    b.HasOne("App_Data.Model.TichDiem", "TichDiem")
                        .WithMany("UuDaiTichDiems")
                        .HasForeignKey("IdtichDiem");

                    b.Navigation("ChiTietTichDiem");

                    b.Navigation("TichDiem");
                });

            modelBuilder.Entity("App_Data.Model.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("App_Data.Model.CartDetail", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("App_Data.Model.ChiTietTichDiem", b =>
                {
                    b.Navigation("UuDaiTichDiems");
                });

            modelBuilder.Entity("App_Data.Model.ChucVu", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("App_Data.Model.Color", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("App_Data.Model.KhachHang", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Carts");
                });

            modelBuilder.Entity("App_Data.Model.NhanVien", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("App_Data.Model.Product", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("App_Data.Model.ProductDetail", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("App_Data.Model.Sale", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("App_Data.Model.Size", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("App_Data.Model.TichDiem", b =>
                {
                    b.Navigation("KhachHangs");

                    b.Navigation("UuDaiTichDiems");
                });

            modelBuilder.Entity("App_Data.Model.UuDaiTichDiem", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("App_Data.Model.Voucher", b =>
                {
                    b.Navigation("Bills");
                });
#pragma warning restore 612, 618
        }
    }
}
