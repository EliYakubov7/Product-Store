import { ChangeDetectorRef, Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { NB_AUTH_OPTIONS, NbAuthResult, NbAuthService, NbLoginComponent, getDeepFromObject } from '@nebular/auth';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrl: './login.component.scss'
})
export class NgxLoginComponent extends NbLoginComponent {

	loginHidePassword: boolean = true;

	constructor(
		protected override service: NbAuthService,
		@Inject(NB_AUTH_OPTIONS) protected override options = {},
		protected override cd: ChangeDetectorRef,
		protected override router: Router
	) {
		super(service, options, cd, router);
	}

	override login(): void {
		this.errors = [];
		this.messages = [];
		this.submitted = true;

		this.service.authenticate(this.strategy, this.user).subscribe((result: NbAuthResult) => {
			this.submitted = false;

			if (result.isSuccess()) {
				this.messages = result.getMessages();
			} else {
				this.errors = this.getErrorsFromApi(result);
			}

			const redirect = result.getRedirect();
			if (redirect) {
				setTimeout(() => {
					return this.router.navigateByUrl(redirect);
				}, this.redirectDelay);
			}

			this.cd.detectChanges();
		});
	}

	override getConfigValue(key: string): any {
		return getDeepFromObject(this.options, key, null);
	}

	private getErrorsFromApi(result: NbAuthResult): string[] {
		return [result.getResponse()?.error];
	}

	loginTogglePasswordVisibility(): void { 
		this.loginHidePassword = !this.loginHidePassword;
	}
}