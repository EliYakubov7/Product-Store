import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, OperatorFunction, catchError, map, of, switchMap, tap } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class ApiService {

	/**
	 * @constructor
	 * @param HttpClient http - HTTP client
	 */
	constructor (
		protected readonly http: HttpClient
	) {}

	/**
	 * HTTP GET API request base function
	 * @returns Observable<T>
	 */
	protected get<T>(endpoint: string): Observable<T> {
		return this.http.get<T>(endpoint).pipe(
			this.responseLogic()
		);
	}

	/**
	 * HTTP POST API request base function
	 * @returns Observable<T>
	 */
	protected post<T>(endpoint: string, body: Object = {}, params: HttpParams = new HttpParams()): Observable<T> {
		return this.http.post<T>(endpoint, body, { params: params }).pipe(
			this.responseLogic()
		);
	}

	/**
	 * HTTP PUT API request base function
	 * @returns Observable<T>
	 */
	protected put<T>(endpoint: string, body: Object = {}, params: HttpParams = new HttpParams()): Observable<T> {
		return this.http.put<T>(endpoint, body, { params: params }).pipe(
			this.responseLogic()
		);
	}

	/**
	 * HTTP DELETE API request base function
	 * @returns Observable<T>
	 */
	protected delete<T>(endpoint: string): Observable<T> {
		return this.http.delete<T>(endpoint).pipe(
			this.responseLogic()
		);
	}

	/**
	 * HTTP request base response logic
	 * @returns OperatorFunction<ApiResponse<T>, any>
	 */
	private responseLogic<T>(): OperatorFunction<T, any> {
		return response$ => response$.pipe(
			switchMap((response) => {
				return of({
					success: true,
					response: response
				});
			}),
			catchError((err) => {
				return of({
					success: false,
					response: err.error
				});
			}),
			tap(
				{
					next: (data) => {
						if (!data.success) {
							console.debug('Error from ApiService HTTP request: ', data);
						} else {
							console.debug('Data from ApiService HTTP request: ', data);
						}
					}
				}
			),
			map(
				data => {
					return data.response;
				}
			)
		);
	}
}