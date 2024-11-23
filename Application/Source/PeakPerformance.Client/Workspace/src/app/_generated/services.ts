import { Injectable } from '@angular/core';
import { HttpParams, HttpClient } from '@angular/common/http';
import { SettingsService } from '../services/settings.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IAuthorizationDto } from './interfaces';
import { ISignupDto } from './interfaces';
import { ISigninDto } from './interfaces';
import { IValidateUserDto } from './interfaces';
import { IValidateUserCodeDto } from './interfaces';
import { IChangePasswordDto } from './interfaces';
import { IPagingResult } from './interfaces';
import { IBodyMeasurementDto } from './interfaces';
import { IBodyMeasurementSearchOptions } from './interfaces';
import { IHealthInformationDto } from './interfaces';
import { IHealthInformationSearchOptions } from './interfaces';
import { IUserDto } from './interfaces';
import { IProfileSetupDto } from './interfaces';
import { IWeightDto } from './interfaces';
import { IWeightSearchOptions } from './interfaces';

@Injectable() export abstract class BaseController
{
	constructor (protected httpClient: HttpClient, protected settingsService: SettingsService) { } 
}
@Injectable() export class AuthController extends BaseController
{
	public Signup(data: ISignupDto) : Observable<IAuthorizationDto | null>
	{
		const body = <any>data;
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
	public Signin(data: ISigninDto) : Observable<IAuthorizationDto | null>
	{
		const body = <any>data;
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
	public ValidateEmail(data: IValidateUserDto) : Observable<any>
	{
		const body = <any>data;
		return this.httpClient.post<any>(
		this.settingsService.createApiUrl('Auth/ValidateEmail'),
		body,
		{
			responseType: 'json',
			observe: 'response',
			withCredentials: true
		})
		.pipe(map(response => response.body));
		
	}
	public ValidateUser(data: IValidateUserDto) : Observable<any>
	{
		const body = <any>data;
		return this.httpClient.post<any>(
		this.settingsService.createApiUrl('Auth/ValidateUser'),
		body,
		{
			responseType: 'json',
			observe: 'response',
			withCredentials: true
		})
		.pipe(map(response => response.body));
		
	}
	public ValidateCode(data: IValidateUserCodeDto) : Observable<any>
	{
		const body = <any>data;
		return this.httpClient.post<any>(
		this.settingsService.createApiUrl('Auth/ValidateCode'),
		body,
		{
			responseType: 'json',
			observe: 'response',
			withCredentials: true
		})
		.pipe(map(response => response.body));
		
	}
	public ChangePassword(data: IChangePasswordDto) : Observable<any>
	{
		const body = <any>data;
		return this.httpClient.post<any>(
		this.settingsService.createApiUrl('Auth/ChangePassword'),
		body,
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
@Injectable() export class BodyMeasurementController extends BaseController
{
	public Search(options: IBodyMeasurementSearchOptions) : Observable<IPagingResult<IBodyMeasurementDto> | null>
	{
		const body = <any>options;
		return this.httpClient.post<IPagingResult<IBodyMeasurementDto>>(
		this.settingsService.createApiUrl('BodyMeasurement/Search'),
		body,
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
@Injectable() export class HealthInformationController extends BaseController
{
	public Search(options: IHealthInformationSearchOptions) : Observable<IPagingResult<IHealthInformationDto> | null>
	{
		const body = <any>options;
		return this.httpClient.post<IPagingResult<IHealthInformationDto>>(
		this.settingsService.createApiUrl('HealthInformation/Search'),
		body,
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
@Injectable() export class UserController extends BaseController
{
	public GetCurrent() : Observable<IUserDto | null>
	{
		return this.httpClient.get<IUserDto>(
		this.settingsService.createApiUrl('User/GetCurrent'),
		{
			responseType: 'json',
			observe: 'response',
			withCredentials: true
		})
		.pipe(map(response => response.body));
		
	}
	public ProfileSetup(data: FormData) : Observable<any>
	{
		const body = <any>data;
		return this.httpClient.post<any>(
		this.settingsService.createApiUrl('User/ProfileSetup'),
		body,
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
@Injectable() export class WeightController extends BaseController
{
	public Search(options: IWeightSearchOptions) : Observable<IPagingResult<IWeightDto> | null>
	{
		const body = <any>options;
		return this.httpClient.post<IPagingResult<IWeightDto>>(
		this.settingsService.createApiUrl('Weight/Search'),
		body,
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
