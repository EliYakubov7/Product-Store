import { NgModule } from '@angular/core';
import { NbLayoutModule, NbSidebarModule, NbIconModule, NbUserModule, NbMenuModule, NbCardModule, NbListModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { LayoutComponent } from './layout.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HubConnectionModule } from 'src/app/shared/modules/hub-connection/hub-connection.module';

@NgModule({
	declarations: [
		LayoutComponent
	],
	imports: [
		CommonModule,
		RouterModule,
		NbLayoutModule,
		NbSidebarModule.forRoot(),
		NbUserModule,
		NbIconModule,
		NbEvaIconsModule,
		NbMenuModule.forRoot(),
		NbCardModule,
		HubConnectionModule,
		NbListModule
	],
	exports: [
		LayoutComponent
	]
})

export class LayoutModule {}