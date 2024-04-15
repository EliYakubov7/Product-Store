import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from 'src/app/shared/services/api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/User';

@Injectable({
	providedIn: 'root'
})
export class UserService extends ApiService {

	constructor (http: HttpClient) {
		super(http);
	}

	getAllUsers(pageNumber: number, pageSize: number): Observable<User[]> {
		return this.get<User[]>(
			`${environment.api_url}/User/All?pageNumber=${pageNumber}&pageSize=${pageSize}`);
	}

	getUserById(userId: number): Observable<User> {
		return this.get<User>(
			`${environment.api_url}/User/${userId}`);
	}

	updateUser(user: User): Observable<any> {
		return this.put(
			`${environment.api_url}/User/Update`, user);
	}

	deleteUser(userId: string): Observable<any> {
		return this.delete(
			`${environment.api_url}/User/${userId}`);
	}
}