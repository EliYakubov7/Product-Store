import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Product } from '../management/pages/product/models/Product';

@Component({
	selector: 'app-product',
	templateUrl: './product.component.html',
	styleUrl: './product.component.scss',
	changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProductComponent implements OnInit {
	@Input() product!: Product;

	ngOnInit(): void {}
}