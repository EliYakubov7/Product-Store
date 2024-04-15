import { Component, OnInit } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';
import { NbAccessChecker } from '@nebular/security';

@Component({
	selector: 'app-layout',
	templateUrl: './layout.component.html',
	styleUrl: './layout.component.scss'
})
export class LayoutComponent implements OnInit {

	items: NbMenuItem[] = [];

	constructor(public accessChecker: NbAccessChecker) {}

	ngOnInit(): void {
		this.accessChecker.isGranted('view', 'admin').subscribe(isGranted => {
			this.items = [
				{
					title: 'Home',
					icon: 'star',
					link: 'home'
				},
				{
					title: 'Admin',
					icon: 'person-outline',
					link: 'management',
					hidden: !isGranted
				},
				{
					title: 'Logout',
					icon: 'unlock-outline',
					link: 'logout'
				},
			];
		});
	}
}