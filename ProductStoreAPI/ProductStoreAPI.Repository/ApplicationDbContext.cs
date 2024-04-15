using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductStoreAPI.Models.Business.Product;
using ProductStoreAPI.Models.Business.User;

namespace ProductStoreAPI.Repository
{
	public sealed class ApplicationDbContext(
		DbContextOptions<ApplicationDbContext> options)
		: IdentityDbContext<User>(options)
	{
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole()
			{
				Id = "8e1ee5b1-61d3-44ea-9433-e0ebb81b7e4c",
				Name = "SiteAdministrator",
				NormalizedName = "SITEADMINISTRATOR".ToUpper()
			});

			var hasher = new PasswordHasher<User>();

			modelBuilder.Entity<User>().HasData(
				new User()
				{
					Id = "9f111e4a-e216-4e13-89cf-fca92ccf89be",
                    UserName = "admin@admin.com",
					Name = "admin",
					NormalizedUserName = "ADMIN",
					Email = "admin@admin.com",
					NormalizedEmail = "admin@admin.com".ToUpper(),
					PasswordHash = hasher.HashPassword(null, "admin")
				}
			);

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string>
				{
					RoleId = "8e1ee5b1-61d3-44ea-9433-e0ebb81b7e4c",
					UserId = "9f111e4a-e216-4e13-89cf-fca92ccf89be"
				}
			);

			modelBuilder.Entity<Product>().HasData(
				new()
				{
                    ProductId = 1,
                    Name = "AMGAZIT 26,000 BTU",
                    Description = "Flatgasit - a luxurious gas plancha with 3 burners from Amgasit. Cooking surface made of high-quality..",
                    Price = 949.00M,
                    StockQuantity = 80,
                    Category = "Cooking",
                    ImageUrl = "https://img.ksp.co.il/item/136742/b_1.jpg?v=5",
                    Manufacturer = "AMGAZIT",
                    IsActive = true
                },
				new()
				{
                    ProductId = 2,
                    Name = "Samsung 50'' Crystal UHD 4K HDR",
                    Description = "Quality 50'' Samsung TV, with amazing Ultra HD 4K resolution, LED lighting, Crystal Processor Lite 4K, HDR support.",
                    Price = 1979.00M,
                    StockQuantity = 150,
                    Category = "Electronics",
                    ImageUrl = "https://img.ksp.co.il/item/302004/b_1.jpg?v=5",
                    Manufacturer = "Samsung",
                    IsActive = true
                },
				new()
				{
					ProductId = 3,
					Name = "Veesh professional nail clipper set",
					Description = "Professional nail clipper set - comes in an elegant water-resistant case.",
					Price = 55.00M,
					StockQuantity = 230,
					Category = "Cosmetics",
					ImageUrl = "https://img.ksp.co.il/item/301733/b_1.jpg?v=5",
					Manufacturer = "Veesh",
					IsActive = true
				},
				new()
				{
					ProductId = 4,
					Name = "Hot Wheels Pull-Back Speeders",
					Description = "Meet the Pull-Back Speeders series with the uniquely designed Hot Wheels racing car.",
					Price = 75.00M,
					StockQuantity = 300,
					Category = "Kids & Games",
					ImageUrl = "https://img.ksp.co.il/item/303749/b_2.jpg?v=5",
					Manufacturer = "HotWheels",
					IsActive = true
				},
				new()
				{
					ProductId = 5,
					Name = "Folding running track model Focus52 from VO2",
					Description = "The Focus52 is a high-quality running track suitable for all fitness levels.",
					Price = 4200.00M,
					StockQuantity = 28,
					Category = "Sport",
					ImageUrl = "https://img.ksp.co.il/item/296982/b_1.jpg?v=5",
					Manufacturer = "VO2",
					IsActive = true
				}
			);

			base.OnModelCreating(modelBuilder);
		}
	}
}
