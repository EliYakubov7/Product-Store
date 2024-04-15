import { AuthGuard } from './shared/guards/auth.guard';
import { mapToCanActivate } from '@angular/router';
import { NonAuthGuard } from './shared/guards/non-auth.guard';
import { LayoutComponent } from './modules/layout/layout.component';
import { NbLogoutComponent } from '@nebular/auth';

type Route = "full";

export const APP_ROUTES = [
	{
		path: '',
		component: LayoutComponent,
		canActivate: mapToCanActivate([AuthGuard]),
		children: [
			{
				path: 'home',
				loadChildren: () => import('./modules/home/home.module').then(mod => mod.HomeModule)
			},
			{
				path: 'management',
				loadChildren: () => import('./modules/management/management.module').then(mod => mod.ManagementModule)
			},
			{
				path: 'logout',
				component: NbLogoutComponent
			},
			{
				path: '',
				pathMatch: 'full' as Route,
				redirectTo: 'home'
			}
		]
	},
	{
		path: 'auth',
		canActivate: mapToCanActivate([NonAuthGuard]),
		loadChildren: () => import('./modules/auth/auth.module').then(mod => mod.NgxAuthModule)
	},
	{
		path: '**',
		redirectTo: 'auth'
	}
];