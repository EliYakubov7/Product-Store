import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/modules/management/pages/user/models/User';
import { UserService } from 'src/app/modules/management/pages/user/services/user.service';
import { RoleProvider } from 'src/app/shared/guards/role.provider';

@Component({
	selector: 'app-user',
	templateUrl: './user.component.html',
	styleUrl: './user.component.scss'
})
export class UserComponent implements OnInit {

	users: User[] = [];

	usersModel!: User;

	userId: string = "";

	showNew: Boolean = false;

	submitType: string = 'Save';

	selectedRow!: number;

	constructor(private readonly userService: UserService, private readonly roleProvider: RoleProvider) {}

	ngOnInit(): void {
		this.roleProvider.getUserId().subscribe(userId => {
			this.userId = userId;
		});

		this.userService.getAllUsers(1, 999).subscribe(users => {
			this.users = users;
		});
	}

	onSave(): void {
		this.users[this.selectedRow].name = this.usersModel.name;
		this.users[this.selectedRow].userName = this.usersModel.userName;
		this.users[this.selectedRow].email = this.usersModel.email;
		this.users[this.selectedRow].emailConfirmed = this.usersModel.emailConfirmed;
		this.users[this.selectedRow].phoneNumber = this.usersModel.phoneNumber;
		this.users[this.selectedRow].phoneNumberConfirmed = this.usersModel.phoneNumberConfirmed;
		this.users[this.selectedRow].twoFactorEnabled = this.usersModel.twoFactorEnabled;
		this.users[this.selectedRow].lockoutEnabled = this.usersModel.lockoutEnabled;

		this.userService.updateUser(this.users[this.selectedRow]).subscribe();

		this.showNew = false;
	}

	onEdit(index: number): void {
		this.selectedRow = index;
		this.usersModel = new User('', '0','');
		this.usersModel = Object.assign({}, this.users[this.selectedRow]);
		this.submitType = 'Update';
		this.showNew = true;
	}

	onDelete(index: number, userId: string): void {
		this.userService.deleteUser(userId).subscribe();
		setTimeout(() => {
			this.ngOnInit();
			if (index === this.selectedRow) {
				this.showNew = false;
			}
		}, 1000);
	}

	onCancel(): void {
		this.showNew = false;
	}
}