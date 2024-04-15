import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NbThemeModule } from '@nebular/theme';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NbPasswordAuthStrategy, NbAuthModule, NbAuthJWTToken } from '@nebular/auth';
import { environment } from 'src/environments/environment';
import { SharedModule } from './shared/shared.module';
import { LayoutModule } from './modules/layout/layout.module';
import { GlobalAuthRequestInterceptor } from './shared/interceptors/globalAuth.interceptor';
import { NbRoleProvider, NbSecurityModule } from '@nebular/security';
import { RoleProvider } from './shared/guards/role.provider';

@NgModule({
	declarations: [
		AppComponent
	],
	imports: [
		BrowserModule,
		AppRoutingModule,
		HttpClientModule,
		NbThemeModule.forRoot(),
		NbAuthModule.forRoot({
			strategies: [
				NbPasswordAuthStrategy.setup({
					name: 'email',
					token: {
						class: NbAuthJWTToken,
						key: 'token'
					},
					baseEndpoint: environment.api_url,
					login: {
						endpoint: '/Auth/Login',
						method: 'post',
						redirect: {
							success: 'home',
							failure: null,
						}
					},
					register: {
						endpoint: '/Auth/Register',
						method: 'post',
						redirect: {
							success: 'home',
							failure: null,
						}
					},
					logout: {
						endpoint: '/Auth/SignOut',
						method: 'post',
						redirect: {
							success: 'auth/login',
							failure: null,
						}
					},
				}),
			],
			forms: {
				logout: {
					redirectDelay: 2500
				},
			},
		}),
		NbSecurityModule.forRoot({
			accessControl: {
				SiteAdministrator: {
					view: ['admin'],
				},
			},
		}),
		SharedModule,
		LayoutModule,
	],
	providers: [
		{
			provide: HTTP_INTERCEPTORS,
			useClass: GlobalAuthRequestInterceptor,
			multi: true
		},
		{
			provide: NbRoleProvider,
			useClass: RoleProvider
		}
	],
	bootstrap: [AppComponent]
})

export class AppModule {}