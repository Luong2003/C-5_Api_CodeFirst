using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chi Tiết tích điểm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoDiemTich = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chi Tiết tích điểm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chức vụ",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaChucVu = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chức vụ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kích Cỡ",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Size1 = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kích Cỡ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mã giảm giá",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    PhanTramGiam = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mã giảm giá", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Màu Sắc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Màu Sắc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sản Phẩm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    TenSp = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sản Phẩm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tích điểm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoDiem = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tích điểm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nhân viên",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdchucVu = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    Ma = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhân viên", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nhân viên_Chức vụ_IdchucVu",
                        column: x => x.IdchucVu,
                        principalTable: "Chức vụ",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sản Phẩm Chi Tiết",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Idproduct = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    Idcolor = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    Idsize = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    CongNgheManHinh = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    BaoHanh = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    DoPhanGiai = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<double>(type: "float", nullable: false),
                    GiaBan = table.Column<double>(type: "float", nullable: false),
                    NhaSanXuat = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    TheLoai = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    NgaySanXuat = table.Column<DateTime>(type: "Datetime", nullable: false),
                    TrangThaiKhuyenMai = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sản Phẩm Chi Tiết", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sản Phẩm Chi Tiết_Kích Cỡ_Idsize",
                        column: x => x.Idsize,
                        principalTable: "Kích Cỡ",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sản Phẩm Chi Tiết_Màu Sắc_Idcolor",
                        column: x => x.Idcolor,
                        principalTable: "Màu Sắc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sản Phẩm Chi Tiết_Sản Phẩm_Idproduct",
                        column: x => x.Idproduct,
                        principalTable: "Sản Phẩm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Khách hàng",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdtichDiem = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khách hàng", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Khách hàng_Tích điểm_IdtichDiem",
                        column: x => x.IdtichDiem,
                        principalTable: "Tích điểm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ưu đãi tích điểm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdchiTietTichDiem = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    IdtichDiem = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    Idbill = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoDiemDung = table.Column<int>(type: "int", nullable: false),
                    NgayTichDiem = table.Column<DateTime>(type: "Datetime", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ưu đãi tích điểm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ưu đãi tích điểm_Chi Tiết tích điểm_IdchiTietTichDiem",
                        column: x => x.IdchiTietTichDiem,
                        principalTable: "Chi Tiết tích điểm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ưu đãi tích điểm_Tích điểm_IdtichDiem",
                        column: x => x.IdtichDiem,
                        principalTable: "Tích điểm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Giỏ hàng chi tiết",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdproductDetails = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giỏ hàng chi tiết", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Giỏ hàng chi tiết_Sản Phẩm Chi Tiết_IdproductDetails",
                        column: x => x.IdproductDetails,
                        principalTable: "Sản Phẩm Chi Tiết",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hóa Đơn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdkhachHang = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    IduuDaiTichDiem = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    IdnhanVien = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    Idvoucher = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    NgayThanhToan = table.Column<DateTime>(type: "Datetime", nullable: false),
                    GiamGia = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    DiaChiShop = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    DiaChiKhachHang = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    TienShip = table.Column<double>(type: "float", nullable: false),
                    FreeShip = table.Column<double>(type: "float", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    SoTienGiam = table.Column<double>(type: "float", nullable: false),
                    TienKhachDua = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hóa Đơn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hóa Đơn_Khách hàng_IdkhachHang",
                        column: x => x.IdkhachHang,
                        principalTable: "Khách hàng",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hóa Đơn_Mã giảm giá_Idvoucher",
                        column: x => x.Idvoucher,
                        principalTable: "Mã giảm giá",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hóa Đơn_Nhân viên_IdnhanVien",
                        column: x => x.IdnhanVien,
                        principalTable: "Nhân viên",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hóa Đơn_Ưu đãi tích điểm_IduuDaiTichDiem",
                        column: x => x.IduuDaiTichDiem,
                        principalTable: "Ưu đãi tích điểm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Giỏ hàng",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdkhachHang = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    IdcartDetails = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giỏ hàng", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Giỏ hàng_Giỏ hàng chi tiết_IdcartDetails",
                        column: x => x.IdcartDetails,
                        principalTable: "Giỏ hàng chi tiết",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Giỏ hàng_Khách hàng_IdkhachHang",
                        column: x => x.IdkhachHang,
                        principalTable: "Khách hàng",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hóa Đơn Chi Tiết",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdproductDetails = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    Idbill = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hóa Đơn Chi Tiết", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hóa Đơn Chi Tiết_Hóa Đơn_Idbill",
                        column: x => x.Idbill,
                        principalTable: "Hóa Đơn",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hóa Đơn Chi Tiết_Sản Phẩm Chi Tiết_IdproductDetails",
                        column: x => x.IdproductDetails,
                        principalTable: "Sản Phẩm Chi Tiết",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Giỏ hàng_IdcartDetails",
                table: "Giỏ hàng",
                column: "IdcartDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Giỏ hàng_IdkhachHang",
                table: "Giỏ hàng",
                column: "IdkhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_Giỏ hàng chi tiết_IdproductDetails",
                table: "Giỏ hàng chi tiết",
                column: "IdproductDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Hóa Đơn_IdkhachHang",
                table: "Hóa Đơn",
                column: "IdkhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_Hóa Đơn_IdnhanVien",
                table: "Hóa Đơn",
                column: "IdnhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_Hóa Đơn_IduuDaiTichDiem",
                table: "Hóa Đơn",
                column: "IduuDaiTichDiem");

            migrationBuilder.CreateIndex(
                name: "IX_Hóa Đơn_Idvoucher",
                table: "Hóa Đơn",
                column: "Idvoucher");

            migrationBuilder.CreateIndex(
                name: "IX_Hóa Đơn Chi Tiết_Idbill",
                table: "Hóa Đơn Chi Tiết",
                column: "Idbill");

            migrationBuilder.CreateIndex(
                name: "IX_Hóa Đơn Chi Tiết_IdproductDetails",
                table: "Hóa Đơn Chi Tiết",
                column: "IdproductDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Khách hàng_IdtichDiem",
                table: "Khách hàng",
                column: "IdtichDiem");

            migrationBuilder.CreateIndex(
                name: "IX_Nhân viên_IdchucVu",
                table: "Nhân viên",
                column: "IdchucVu");

            migrationBuilder.CreateIndex(
                name: "IX_Sản Phẩm Chi Tiết_Idcolor",
                table: "Sản Phẩm Chi Tiết",
                column: "Idcolor");

            migrationBuilder.CreateIndex(
                name: "IX_Sản Phẩm Chi Tiết_Idproduct",
                table: "Sản Phẩm Chi Tiết",
                column: "Idproduct");

            migrationBuilder.CreateIndex(
                name: "IX_Sản Phẩm Chi Tiết_Idsize",
                table: "Sản Phẩm Chi Tiết",
                column: "Idsize");

            migrationBuilder.CreateIndex(
                name: "IX_Ưu đãi tích điểm_IdchiTietTichDiem",
                table: "Ưu đãi tích điểm",
                column: "IdchiTietTichDiem");

            migrationBuilder.CreateIndex(
                name: "IX_Ưu đãi tích điểm_IdtichDiem",
                table: "Ưu đãi tích điểm",
                column: "IdtichDiem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Giỏ hàng");

            migrationBuilder.DropTable(
                name: "Hóa Đơn Chi Tiết");

            migrationBuilder.DropTable(
                name: "Giỏ hàng chi tiết");

            migrationBuilder.DropTable(
                name: "Hóa Đơn");

            migrationBuilder.DropTable(
                name: "Sản Phẩm Chi Tiết");

            migrationBuilder.DropTable(
                name: "Khách hàng");

            migrationBuilder.DropTable(
                name: "Mã giảm giá");

            migrationBuilder.DropTable(
                name: "Nhân viên");

            migrationBuilder.DropTable(
                name: "Ưu đãi tích điểm");

            migrationBuilder.DropTable(
                name: "Kích Cỡ");

            migrationBuilder.DropTable(
                name: "Màu Sắc");

            migrationBuilder.DropTable(
                name: "Sản Phẩm");

            migrationBuilder.DropTable(
                name: "Chức vụ");

            migrationBuilder.DropTable(
                name: "Chi Tiết tích điểm");

            migrationBuilder.DropTable(
                name: "Tích điểm");
        }
    }
}
