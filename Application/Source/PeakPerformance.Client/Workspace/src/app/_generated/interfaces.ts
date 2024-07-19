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
	verifyCode: number;
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
export interface IEmailDto
{
	toEmail: string;
	subject: string;
	body: string;
}
