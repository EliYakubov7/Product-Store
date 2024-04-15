import { HomeMainComponent } from "./pages/home-main/home-main.component";
import { HomeComponent } from "./pages/home/home.component";

export const HOME_ROUTES = [
	{
		path: '',
		component: HomeMainComponent,
		children: [
			{
				path: '',
				component: HomeComponent
			},
		]
	}
];