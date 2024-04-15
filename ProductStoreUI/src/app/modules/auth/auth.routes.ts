import { NbAuthComponent } from "@nebular/auth";
import { NgxLoginComponent } from "./pages/login/login.component";
import { NgxRegisterComponent } from "./pages/registration/register.component";

export const AUTH_ROUTES = [
	{
		path: '',
		component: NbAuthComponent,
		children: [
			{
				path: 'login',
				component: NgxLoginComponent,
			},
			{
				path: 'register',
				component: NgxRegisterComponent,
			},
			{
				path: '**',
				redirectTo: 'login'
			}
		],
	},
];