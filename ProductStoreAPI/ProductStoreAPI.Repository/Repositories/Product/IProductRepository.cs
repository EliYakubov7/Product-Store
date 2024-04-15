using System.Collections.Generic;
using System.Threading.Tasks;
using ProductDto = ProductStoreAPI.Models.Business.Product;

namespace ProductStoreAPI.Repository.Repositories.Product
{
	public interface IProductRepository
	{
		/// <summary>
		/// Retrieves a paginated list of products, ordered by category.
		/// </summary>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The number of items per page.</param>
		/// <returns>A list of products for the specified page.</returns>
		Task<IList<ProductDto.Product>> GetAllProductsAsync(
			int pageNumber,
			int pageSize);

		/// <summary>
		/// Retrieves a single product by its ID.
		/// </summary>
		/// <param name="productId">The ID of the product to retrieve.</param>
		/// <returns>The product if found; otherwise, null.</returns>
		Task<ProductDto.Product> GetProductByIdAsync(
			long productId);

		/// <summary>
		/// Creates a new product in the database.
		/// </summary>
		/// <param name="product">The product to create.</param>
		/// <returns>True if the product is successfully created; otherwise, false.</returns>
		Task<bool> CreateProductAsync(
			ProductDto.Product product);

		/// <summary>
		/// Updates an existing product in the database.
		/// </summary>
		/// <param name="product">The product to update.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task UpdateProductAsync(
			ProductDto.Product product);

		/// <summary>
		/// Deletes a product by its ID.
		/// </summary>
		/// <param name="productId">The ID of the product to delete.</param>
		/// <returns>True if the product is successfully deleted; otherwise, false.</returns>
		Task<bool> DeleteProductAsync(
			long productId);
	}
}
