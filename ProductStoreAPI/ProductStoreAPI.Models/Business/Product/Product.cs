using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductStoreAPI.Models.Business.Product
{
	public sealed class Product
	{
		[Key]
		[Column("id")]
		public long ProductId { get; init; }

		[Required]
		[Column("name")]
		public required string Name { get; init; }

		[Column("description")]
		public string Description { get; init; }

		[Column("price")]
		public decimal Price { get; init; } = decimal.Zero;

		[Column("stock_quantity")]
		public int StockQuantity { get; init; } = 0;

		[Column("category")]
		public string Category { get; init; }

		[Column("image_url")]
		public string ImageUrl { get; init; }

		[Column("manufacturer")]
		public string Manufacturer { get; init; }

		[Column("is_active")]
		public bool IsActive { get; init; } = false;
	}
}
