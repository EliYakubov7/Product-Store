import { Injectable } from '@angular/core';
import { NbAuthService } from '@nebular/auth';

@Injectable({
	providedIn: 'root'
})

export class NgxAuthService extends NbAuthService {}