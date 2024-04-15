using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductDto = ProductStoreAPI.Models.Business.Product;

namespace ProductStoreAPI.Repository.Repositories.Product
{
	public sealed class ProductRepository(
		ApplicationDbContext context)
		: IProductRepository
	{
		public async Task<IList<ProductDto.Product>> GetAllProductsAsync(
			int pageNumber,
			int pageSize)
		{
			if (pageNumber < 1)
				throw new ArgumentException("Page number must be greater than 0.", nameof(pageNumber));

			if (pageSize < 1)
				throw new ArgumentException("Page size must be greater than 0.", nameof(pageSize));

			try
			{
				return await context.Products
					.Skip((pageNumber - 1) * pageSize)
					.Take(pageSize)
					.OrderBy(x => x.Category)
					.ToListAsync();
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(
					$"Error while trying to GetAllProductsAsync: {ex.Message}");

				throw;
			}
		}

		public async Task<ProductDto.Product> GetProductByIdAsync(
			long productId)
		{
			ProductDto.Product product = null;

			try
			{
				product = await context.Products.FindAsync(
					productId);
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(
					$"Error while trying to GetProductAsync: {ex.Message}");

				throw;
			}

			return product;
		}

		public async Task<bool> CreateProductAsync(
			ProductDto.Product Product)
		{
			try
			{
				context.Products.Add(Product);

				await context.SaveChangesAsync();

				return true;
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(
					$"Error while trying to CreateProductAsync: {ex.Message}");

				return false;
			}
		}

		public async Task UpdateProductAsync(
			ProductDto.Product Product)
		{
			try
			{
				context.Products.Update(Product);

				await context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(
					$"Error while trying to UpdateProductAsync: {ex.Message}");

				throw;
			}
		}

		public async Task<bool> DeleteProductAsync(
			long productId)
		{
			bool isDeleted = false;

			try
			{
				var product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

				if (product != null)
				{
					context.Products.Remove(product);

					await context.SaveChangesAsync();

					isDeleted = true;
				}
				else
				{
					await Console.Out.WriteLineAsync(
						$"Product with {nameof(productId)}: {productId}, not found!");
				}
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(
					$"Error while trying to DeleteProductAsync with {nameof(productId)}: {productId}, {ex.Message}");

				throw;
			}

			return isDeleted;
		}
	}
}
