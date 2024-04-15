import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/modules/management/pages/product/services/product.service';
import { Product } from 'src/app/modules/management/pages/product/models/Product';
import { Observable } from 'rxjs';
import { NbSearchService, NbSortDirection, NbTreeGridDataSource, NbTreeGridDataSourceBuilder } from '@nebular/theme';

@Component({
	selector: 'app-home',
	templateUrl: './home.component.html',
	styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

	productObs$!: Observable<Product[]>;

	dataSource!: NbTreeGridDataSource<Product>;

	products: Product[] = [];
	filteredProducts: Product[] = [];

	constructor(
		private readonly productService: ProductService,
		private readonly dataSourceBuilder: NbTreeGridDataSourceBuilder<Product>
	) {}

	ngOnInit(): void {
		this.productService.getAllProducts(1, 999).subscribe(products => {
			this.products = products;
			this.filteredProducts = products;
		});
	}

	filterResults(text: string) {
		if (!text) {
			this.filteredProducts = this.products;
			return;
		}
	
		this.filteredProducts = this.products.filter(
			product => product?.name.toLowerCase().includes(text.toLowerCase())
		);
	}
}