import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NbAuthModule } from '@nebular/auth';
import {
	NbAlertModule,
	NbButtonModule,
	NbCheckboxModule,
	NbIconModule,
	NbInputModule
} from '@nebular/theme';
import { AUTH_ROUTES } from './auth.routes';
import { NgxLoginComponent } from './pages/login/login.component';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NgxRegisterComponent } from './pages/registration/register.component';

@NgModule({
	imports: [
		RouterModule.forChild(AUTH_ROUTES),
		CommonModule,
		FormsModule,
		RouterModule,
		NbAlertModule,
		NbInputModule,
		NbButtonModule,
		NbCheckboxModule,
		NbAuthModule,
		NbIconModule,
		NbEvaIconsModule,
	],
	declarations: [
		NgxLoginComponent,
		NgxRegisterComponent
	],
})

export class NgxAuthModule {}