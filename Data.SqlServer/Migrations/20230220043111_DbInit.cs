using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.SqlServer.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CacViTri",
                columns: table => new
                {
                    vitri_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vitri_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CacViTri", x => x.vitri_id);
                });

            migrationBuilder.CreateTable(
                name: "MenuMain",
                columns: table => new
                {
                    order = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    menu_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menu_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    menu_url = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMain", x => x.menu_id);
                });

            migrationBuilder.CreateTable(
                name: "SuKien",
                columns: table => new
                {
                    order = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    event_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    event_title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    event_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    event_image = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuKien", x => x.event_id);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    order = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoai", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoaiTin",
                columns: table => new
                {
                    order = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTin", x => x.type_id);
                    table.ForeignKey(
                        name: "FK_LoaiTin_TheLoai_category_id",
                        column: x => x.category_id,
                        principalTable: "TheLoai",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuangCao",
                columns: table => new
                {
                    quangcao_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quangcao_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    vitri_id = table.Column<int>(type: "int", nullable: false),
                    qunagcao_image = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuangCao", x => x.quangcao_id);
                    table.ForeignKey(
                        name: "FK_QuangCao_CacViTri_vitri_id",
                        column: x => x.vitri_id,
                        principalTable: "CacViTri",
                        principalColumn: "vitri_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuangCao_LoaiTin_type_id",
                        column: x => x.type_id,
                        principalTable: "LoaiTin",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tin",
                columns: table => new
                {
                    order = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    news_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    news_title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    news_tomtat = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    news_content = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    news_image = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    news_soluot_xem = table.Column<int>(type: "int", nullable: false),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    bool_tinnoibat = table.Column<bool>(type: "bit", nullable: false),
                    news_keyword = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tin", x => x.news_id);
                    table.ForeignKey(
                        name: "FK_Tin_LoaiTin_type_id",
                        column: x => x.type_id,
                        principalTable: "LoaiTin",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuMain",
                columns: new[] { "menu_id", "created_date", "description", "menu_name", "menu_url", "modified_date", "order", "parent_id", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9258), "", "Trang chủ", "/#", null, 0, 0, true },
                    { 2, new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9260), "", "Giới thiệu", "/gioi-thieu", null, 0, 0, true },
                    { 3, new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9262), "", "Trang 3", "/trang3", null, 0, 0, true },
                    { 4, new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9263), "", "Trang 34", "/trang4", null, 0, 3, true },
                    { 5, new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9264), "", "Trang 35", "/trang5", null, 0, 3, true }
                });

            migrationBuilder.InsertData(
                table: "SuKien",
                columns: new[] { "event_id", "created_date", "description", "event_date", "event_image", "event_title", "modified_date", "order", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9102), "", new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9101), "a.png", "Sự kiện 11", null, 0, true },
                    { 2, new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9104), "", new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9103), "a.png", "Sự kiện 12", null, 0, true },
                    { 3, new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9106), "", new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9106), "a.png", "Sự kiện 13", null, 0, true },
                    { 4, new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9108), "", new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9108), "a.png", "Sự kiện 14", null, 0, true },
                    { 5, new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9111), "", new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9110), "a.png", "Sự kiện 15", null, 0, true },
                    { 6, new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9113), "", new DateTime(2023, 2, 20, 11, 31, 11, 444, DateTimeKind.Local).AddTicks(9112), "a.png", "Sự kiện 16", null, 0, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiTin_category_id",
                table: "LoaiTin",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_QuangCao_type_id",
                table: "QuangCao",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_QuangCao_vitri_id",
                table: "QuangCao",
                column: "vitri_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tin_type_id",
                table: "Tin",
                column: "type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MenuMain");

            migrationBuilder.DropTable(
                name: "QuangCao");

            migrationBuilder.DropTable(
                name: "SuKien");

            migrationBuilder.DropTable(
                name: "Tin");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CacViTri");

            migrationBuilder.DropTable(
                name: "LoaiTin");

            migrationBuilder.DropTable(
                name: "TheLoai");
        }
    }
}
