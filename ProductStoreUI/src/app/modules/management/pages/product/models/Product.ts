export class Product {
	productId: number;
	name: string;
	description: string;
	price: number;
	stockQuantity: number;
	category: string;
	imageUrl: string;
	manufacturer: string;
	isActive: boolean;

	constructor(
		productId: number,
		name: string = '',
		description: string = '',
		price: number = 0,
		stockQuantity: number = 0,
		category: string = '',
		imageUrl: string = '',
		manufacturer: string = '',
		isActive: boolean = false,
	) {
		this.productId = productId;
		this.name = name;
		this.description = description;
		this.price = price;
		this.stockQuantity = stockQuantity;
		this.category = category;
		this.imageUrl = imageUrl;
		this.manufacturer = manufacturer;
		this.isActive = isActive;
	}
}