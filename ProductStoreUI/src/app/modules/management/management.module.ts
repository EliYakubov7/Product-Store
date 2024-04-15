import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MANAGEMENT_ROUTES } from './management.routes';
import { ManagementMainComponent } from './pages/management-main/management-main.component';
import { ManagementComponent } from './pages/management/management.component';
import { NbButtonModule, NbCardModule, NbInputModule, NbTableModule, NbTabsetModule, NbTreeGridModule } from '@nebular/theme';
import { CommonModule } from '@angular/common';
import { UserComponent } from './pages/user/user.component';
import { FormsModule } from '@angular/forms';
import { ProductComponent } from './pages/product/product.component';
import { RoleProvider } from 'src/app/shared/guards/role.provider';

@NgModule({
	declarations: [
		ManagementMainComponent,
		ManagementComponent,
		ProductComponent,
		UserComponent
	],
	imports: [
		RouterModule.forChild(MANAGEMENT_ROUTES),
		CommonModule,
		NbTableModule,
		NbTabsetModule,
		NbTreeGridModule,
		NbCardModule,
		NbInputModule,
		FormsModule,
		NbButtonModule
	],
	providers: [
		RoleProvider
	],
})

export class ManagementModule {}