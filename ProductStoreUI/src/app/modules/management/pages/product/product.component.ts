import { Component } from '@angular/core';
import { Product } from 'src/app/modules/management/pages/product/models/Product';
import { ProductService } from 'src/app/modules/management/pages/product/services/product.service';

@Component({
	selector: 'app-product',
	templateUrl: './product.component.html',
	styleUrl: './product.component.scss'
})
export class ProductComponent {
	products: Product[] = [];

	productsModel!: Product;

	showNew: Boolean = false;

	submitType: string = 'Save';

	selectedRow!: number;

	constructor(private readonly productService: ProductService) {}

	ngOnInit(): void {
		this.productService.getAllProducts(1, 999).subscribe(products => {
			this.products = products;
		});
	}

	onNew(): void {
		this.productsModel = new Product(0);
		this.submitType = 'Save';
		this.showNew = true;
	}

	onSave(): void {
		if (this.submitType === 'Save') {
			this.products.push(this.productsModel);
			this.productService.createProduct(this.productsModel).subscribe();
			setTimeout(() => {
				this.ngOnInit();
			}, 1000);
		} else {
			this.products[this.selectedRow].name = this.productsModel.name;
			this.products[this.selectedRow].description = this.productsModel.description;
			this.products[this.selectedRow].price = this.productsModel.price;
			this.products[this.selectedRow].stockQuantity = this.productsModel.stockQuantity;
			this.products[this.selectedRow].category = this.productsModel.category;
			this.products[this.selectedRow].imageUrl = this.productsModel.imageUrl;
			this.products[this.selectedRow].manufacturer = this.productsModel.manufacturer;
			this.products[this.selectedRow].isActive = this.productsModel.isActive;
			this.productService.updateProduct(this.products[this.selectedRow]).subscribe();
		}
		this.showNew = false;
	}

	onEdit(index: number): void {
		this.selectedRow = index;
		this.productsModel = new Product(0);
		this.productsModel = Object.assign({}, this.products[this.selectedRow]);
		this.submitType = 'Update';
		this.showNew = true;
	}

	onDelete(index: number, productId: number): void {
		this.products.splice(index, 1);
		this.productService.deleteProduct(productId).subscribe();

		if (index === this.selectedRow) {
			this.showNew = false;
		}
	}

	onCancel(): void {
		this.showNew = false;
	}
}