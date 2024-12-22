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
	measurementUnitId: number;
}
export interface IChallengeDto
{
	name: string;
	description: string;
	startDate: Date;
	endDate: Date;
	maxParticipants?: number;
	minParticipants?: number;
	statusId: number;
	approvedBy?: number;
	approvedOn?: Date | null;
	isRestricted: boolean;
}
export interface IEmailDto
{
	toEmail: string;
	subject: string;
	body: string;
}
export interface IHealthInformationDto
{
	injuryTypeId: number;
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
	platformId: number;
	link: string;
	phoneNumber: string;
}
export interface IUserTrainingGoalDto
{
	trainingGoalId: number;
	startDate: Date;
	endDate?: Date | null;
}
export interface IWeightDto
{
	weight?: number;
	weightUnitId: number;
	bodyFatPercentage?: number;
	logDate?: Date | null;
}
export interface IWeightGoalDto
{
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
