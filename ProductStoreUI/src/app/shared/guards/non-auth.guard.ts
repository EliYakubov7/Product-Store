import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { NbAuthService } from '@nebular/auth';
import { Observable, map, tap } from 'rxjs';

@Injectable({providedIn: 'root'})
export class NonAuthGuard {

	constructor (
		private readonly authService: NbAuthService,
		private readonly router: Router
	) {}

	canActivate(
		route?: ActivatedRouteSnapshot,
		state?: RouterStateSnapshot): Observable<boolean> {
		return this.authService.isAuthenticated()
			.pipe(
				tap(authenticated => {
					if (authenticated) {
						this.router.navigate(['home']);
					}
				}),
				map((authenticated) => !authenticated)
			);
	}
}