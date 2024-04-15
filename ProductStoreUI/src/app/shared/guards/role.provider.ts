import { Injectable } from '@angular/core';
import { NbAuthService } from '@nebular/auth';
import { NbRoleProvider } from '@nebular/security';
import { Observable, map, tap } from 'rxjs';

@Injectable()
export class RoleProvider implements NbRoleProvider {

	constructor(private readonly authService: NbAuthService) {}

	getRole(): Observable<string> {
		return this.authService.onTokenChange().pipe(
			map((token: any) => {
				return token.isValid() ? token.getPayload()['role'] : 'guest';
			})
		);
	}

	getUserId(): Observable<string> {
		return this.authService.onTokenChange().pipe(
		  map((token: any) => {
			return token.isValid() ? token.getPayload()['nameid'] : '';
		  })
		);
	}
}