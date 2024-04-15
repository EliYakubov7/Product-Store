import { Component, OnInit } from '@angular/core';
import { NbLogoutComponent } from '@nebular/auth';

@Component({
	selector: 'app-register',
	template: '',
	styles: []
})
export class NgxLogoutComponent extends NbLogoutComponent implements OnInit {

	override ngOnInit(): void {
		super.ngOnInit();

		setTimeout(() => {
			this.router.navigate(['auth/login']);
		}, 2500);
	}
}