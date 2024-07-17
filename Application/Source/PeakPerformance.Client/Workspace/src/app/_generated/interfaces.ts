export interface IAuthorizationDto
{
	token: string;
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
export interface IEmailDto
{
	toEmail: string;
	subject: string;
	body: string;
}
