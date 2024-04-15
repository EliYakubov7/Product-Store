import { Injectable } from '@angular/core';
import { HttpInterceptor } from '@angular/common/http';
import { HttpRequest } from '@angular/common/http';
import { Observable, switchMap } from 'rxjs';
import { HttpHandler } from '@angular/common/http';
import { HttpEvent } from '@angular/common/http';
import { NbAuthService } from '@nebular/auth';

@Injectable({
	providedIn: 'root'
})
export class GlobalAuthRequestInterceptor implements HttpInterceptor {

	constructor(private readonly authService: NbAuthService) {}

	intercept(
		_req: HttpRequest<any>,
		_next: HttpHandler): Observable<HttpEvent<any>> {
		return this.authService.getToken().pipe(
			switchMap((tokenInfo) => {
				if (tokenInfo.isValid()) {
					const modReq = _req.clone({
						setHeaders: {
							'Authorization': `Bearer ${tokenInfo.getValue()}`
						}
					});

					return _next.handle(modReq);
				}

				return _next.handle(_req);
			})
		);
	}
}