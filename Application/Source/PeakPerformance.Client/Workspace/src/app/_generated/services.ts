import { Injectable } from '@angular/core';
import { HttpParams, HttpClient } from '@angular/common/http';
import { SettingsService } from '../services/settings.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IAuthorizationDto } from './interfaces';
import { ISignupDto } from './interfaces';
import { ISigninDto } from './interfaces';

@Injectable() export abstract class BaseController
{
	constructor (protected httpClient: HttpClient, protected settingsService: SettingsService) { } 
}
@Injectable() export class AuthController extends BaseController
{
	public Signup(user: ISignupDto) : Observable<IAuthorizationDto | null>
	{
		const body = <any>user;
		return this.httpClient.post<IAuthorizationDto>(
		this.settingsService.createApiUrl('Auth/Signup'),
		body,
		{
			responseType: 'json',
			observe: 'response',
			withCredentials: true
		})
		.pipe(map(response => response.body));
		
	}
	public Signin(user: ISigninDto) : Observable<IAuthorizationDto | null>
	{
		const body = <any>user;
		return this.httpClient.post<IAuthorizationDto>(
		this.settingsService.createApiUrl('Auth/Signin'),
		body,
		{
			responseType: 'json',
			observe: 'response',
			withCredentials: true
		})
		.pipe(map(response => response.body));
		
	}
	public Signout() : Observable<any>
	{
		return this.httpClient.post<any>(
		this.settingsService.createApiUrl('Auth/Signout'),
		null,
		{
			responseType: 'json',
			observe: 'response',
			withCredentials: true
		})
		.pipe(map(response => response.body));
		
	}
	constructor (httpClient: HttpClient, settingsService: SettingsService)
	{
		super(httpClient, settingsService);
	}
}
@Injectable() export class TestController extends BaseController
{
	constructor (httpClient: HttpClient, settingsService: SettingsService)
	{
		super(httpClient, settingsService);
	}
}
