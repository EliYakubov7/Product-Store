import { NgModule } from '@angular/core';
import { ProductComponent } from './product.component';
import { NbCardModule } from '@nebular/theme';

@NgModule({
	declarations: [
		ProductComponent
	],
	imports: [
		NbCardModule
	],
	exports: [
		ProductComponent
	]
})
export class ProductModule {}