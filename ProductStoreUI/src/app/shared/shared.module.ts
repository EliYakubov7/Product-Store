import { NgModule } from '@angular/core';
import { ApiService } from './services/api.service';
import { NgxAuthService } from './services/auth.service';

@NgModule({
	providers: [
		ApiService,
		NgxAuthService,
	]
})

export class SharedModule {}