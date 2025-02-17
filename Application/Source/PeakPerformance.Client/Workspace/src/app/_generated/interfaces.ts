import { eMeasurementUnit } from './enums';
import { eInjuryType } from './enums';
import { eSocialMediaPlatform } from './enums';
import { eTrainingGoal } from './enums';
import { eChartTimespan } from './enums';

export interface IAuthorizationDto
{
	token: string;
}
export interface IChangePasswordDto
{
	username: string;
	email: string;
	password: string;
	confirmPassword: string;
}
export interface ISigninDto
{
	username: string;
	password: string;
}
export interface ISignupDto
{
	firstName: string;
	middleName?: string;
	lastName: string;
	username: string;
	email: string;
	password: string;
	confirmPassword: string;
	dateOfBirth: Date;
	phoneNumber: string;
	verificationCode: number;
}
export interface IValidateUserCodeDto
{
	email: string;
	verifyCode: number;
}
export interface IValidateUserDto
{
	username: string;
	email: string;
}
export interface IBodyFatGoalDto
{
	targetBodyFatPercentage: number;
	startDate: Date;
	endDate: Date;
}
export interface IBodyMeasurementDto
{
	waist?: number;
	hips?: number;
	neck?: number;
	chest?: number;
	shoulders?: number;
	rightBicep?: number;
	leftBicep?: number;
	rightForearm?: number;
	leftForearm?: number;
	rightThigh?: number;
	leftThigh?: number;
	rightCalf?: number;
	leftCalf?: number;
	measurementUnitId: eMeasurementUnit;
}
export interface IEmailDto
{
	toEmail: string;
	subject: string;
	body: string;
}
export interface IHealthInformationDto
{
	injuryTypeId: eInjuryType;
	description: string;
	startDate?: Date | null;
	endDate?: Date | null;
	isCondition: boolean;
}
export interface IEnumProvider
{
	id: number;
	name: string;
	description: string;
}
export interface ILookupValueDto
{
	id: number;
	name: string;
	description: string;
}
export interface IProfileSetupDto
{
	weight: IWeightDto;
	bodyMeasurement: IBodyMeasurementDto;
	userTrainingGoal: IUserTrainingGoalDto;
	weightGoal: IWeightGoalDto;
	bodyFatGoal: IBodyFatGoalDto;
	image: any;
	description: string;
	receiveNews: boolean;
	socialMedia: ISocialMediaDto[];
	healthInformation: IHealthInformationDto[];
}
export interface IUserDto
{
	fullName: string;
	username: string;
	email: string;
	dateOfBirth: Date;
	phoneNumber: string;
	description: string;
	profilePictureUrl: string;
}
export interface ISocialMediaDto
{
	platformId: eSocialMediaPlatform;
	link: string;
	phoneNumber: string;
}
export interface IUserTrainingGoalDto
{
	trainingGoalId: eTrainingGoal;
	startDate: Date;
	endDate?: Date | null;
}
export interface IWeightDto
{
	id: number;
	weight?: number;
	weightUnitId: eMeasurementUnit;
	bodyFatPercentage?: number;
	logDate?: Date | null;
}
export interface IWeightGoalDto
{
	id: number;
	targetWeight: number;
	startDate: Date;
	endDate: Date;
}
export interface IPagingResult<TEntity>
{
	data: TEntity[];
	total: number;
}
export interface ISearchOptions
{
	skip: number;
	take: number;
	sortingOptions: ISortingOptions[];
	filter: string;
	totalCount?: boolean;
}
export interface ISortingOptions
{
	field: string;
	dir: string;
	desc: boolean;
}
export interface IWeightSearchOptions extends ISearchOptions
{
	userId?: number;
	fromDate?: Date | null;
	toDate?: Date | null;
	chartTimespanId?: eChartTimespan;
}
export interface IBodyMeasurementSearchOptions extends ISearchOptions
{
	userId?: number;
}
export interface IChallengeSearchOptions extends ISearchOptions
{
	userId?: number;
}
export interface IHealthInformationSearchOptions extends ISearchOptions
{
	userId?: number;
}
export interface IWeightGoalSearchOptions extends ISearchOptions
{
	userId?: number;
	fromDate?: Date | null;
	toDate?: Date | null;
	chartTimespanId?: eChartTimespan;
}
