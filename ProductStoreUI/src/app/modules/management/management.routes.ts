import { ManagementMainComponent } from "./pages/management-main/management-main.component";
import { ManagementComponent } from "./pages/management/management.component";

export const MANAGEMENT_ROUTES = [
	{
		path: '',
		component: ManagementMainComponent,
		children: [
			{
				path: 'admin',
				component: ManagementComponent,
			},
			{
				path: '**',
				redirectTo: 'admin'
			}
		]
	}
];