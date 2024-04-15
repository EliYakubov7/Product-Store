import { NgModule } from '@angular/core';
import { HubConnectionComponent } from './hub-connection.component';
import { NbCardModule, NbUserModule } from '@nebular/theme';
import { CommonModule } from '@angular/common';

@NgModule({
	declarations: [
		HubConnectionComponent
	],
	imports: [
		CommonModule,
		NbUserModule,
		NbCardModule
	],
	exports: [
		HubConnectionComponent
	]
})
export class HubConnectionModule {}
