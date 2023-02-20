using Data.SqlServer.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Data.SqlServer.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        #region
        public DbSet<TheLoai>? TheLoais { get; set; }
        public DbSet<LoaiTin>? LoaiTins { get; set; }
        public DbSet<Tin>? Tins { get; set; }
        public DbSet<CacViTri>? CacViTris { get; set; }
        public DbSet<QuangCao>? QuangCaos { get; set; }
        public DbSet<SuKien>? SuKiens { get; set; }
        public DbSet<MenuMain>? MenuMains { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region   Thêm dữ liệu cho data base
            modelBuilder.Entity<SuKien>().HasData(
                new SuKien { EventId = 1, EventName = "Sự kiện 11", EventDate=DateTime.Now, EventImageUrl = "a.png", CreatedDate = DateTime.Now},
                new SuKien { EventId = 2, EventName = "Sự kiện 12", EventDate=DateTime.Now, EventImageUrl = "a.png", CreatedDate = DateTime.Now},
                new SuKien { EventId = 3, EventName = "Sự kiện 13", EventDate=DateTime.Now, EventImageUrl = "a.png", CreatedDate = DateTime.Now},
                new SuKien { EventId = 4, EventName = "Sự kiện 14", EventDate=DateTime.Now, EventImageUrl = "a.png", CreatedDate = DateTime.Now},
                new SuKien { EventId = 5, EventName = "Sự kiện 15", EventDate=DateTime.Now, EventImageUrl = "a.png", CreatedDate = DateTime.Now},
                new SuKien { EventId = 6, EventName = "Sự kiện 16", EventDate=DateTime.Now, EventImageUrl = "a.png", CreatedDate = DateTime.Now}
            );

            modelBuilder.Entity<MenuMain>().HasData(
                new MenuMain {MenuId =1, MenuName="Trang chủ", ParentId=0,MenuUrl="/#"},
                new MenuMain {MenuId =2, MenuName="Giới thiệu", ParentId=0,MenuUrl="/gioi-thieu"},
                new MenuMain {MenuId =3, MenuName="Trang 3", ParentId=0,MenuUrl="/trang3"},
                new MenuMain {MenuId =4, MenuName="Trang 34", ParentId=3,MenuUrl="/trang4"},
                new MenuMain {MenuId =5, MenuName="Trang 35", ParentId=3,MenuUrl="/trang5"}
            );
            #endregion
        }
    }
}
