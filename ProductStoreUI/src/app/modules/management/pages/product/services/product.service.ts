import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from 'src/app/shared/services/api.service';
import { Product } from '../models/Product';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class ProductService extends ApiService {

	constructor (http: HttpClient) {
		super(http);
	}

	getAllProducts(pageNumber: number, pageSize: number): Observable<Product[]> {
		return this.get<Product[]>(
			`${environment.api_url}/Product/All?pageNumber=${pageNumber}&pageSize=${pageSize}`);
	}

	getProductById(productId: number): Observable<Product> {
		return this.get<Product>(
			`${environment.api_url}/Product/${productId}`);
	}

	createProduct(product: Product): Observable<Product> {
		return this.post<Product>(
			`${environment.api_url}/Product/Create`, product);
	}

	updateProduct(product: Product): Observable<any> {
		return this.put(
			`${environment.api_url}/Product/Update`, product);
	}

	deleteProduct(productId: number): Observable<any> {
		return this.delete(
			`${environment.api_url}/Product/${productId}`);
	}

}
