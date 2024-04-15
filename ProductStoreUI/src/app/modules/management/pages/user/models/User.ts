export class User {
	name: string;
	id: string;
	userName: string;
	email: string;
	emailConfirmed: boolean;
	phoneNumber: string;
	phoneNumberConfirmed: boolean;
	twoFactorEnabled: boolean;
	lockoutEnabled: boolean;

	constructor(
		name: string = '',
		id: string,
		userName: string = '',
		email: string = '',
		emailConfirmed: boolean = false,
		phoneNumber: string = '',
		phoneNumberConfirmed: boolean = false,
		twoFactorEnabled: boolean = false,
		lockoutEnabled: boolean = false,
	) {
		this.name = name,
		this.id = id,
		this.userName = userName,
		this.email = email,
		this.emailConfirmed = emailConfirmed,
		this.phoneNumber = phoneNumber,
		this.phoneNumberConfirmed = phoneNumberConfirmed,
		this.twoFactorEnabled = twoFactorEnabled,
		this.lockoutEnabled = lockoutEnabled
	}
}