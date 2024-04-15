import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NbButtonModule, NbCardModule, NbInputModule, NbLayoutModule, NbSearchModule, NbSidebarModule, NbTabsetModule, NbTreeGridModule } from '@nebular/theme';
import { HomeComponent } from './pages/home/home.component';
import { HOME_ROUTES } from './home.routes';
import { HomeMainComponent } from './pages/home-main/home-main.component';
import { ProductModule } from '../product/product.module';
import { CommonModule } from '@angular/common';

@NgModule({
	declarations: [
		HomeMainComponent,
		HomeComponent
	],
	imports: [
		RouterModule.forChild(HOME_ROUTES),
		CommonModule,
		NbButtonModule,
		ProductModule,
		NbSearchModule,
		NbLayoutModule,
		NbCardModule,
		NbSidebarModule,
		NbTreeGridModule,
		NbInputModule,
		NbTabsetModule,
	],
})

export class HomeModule {}