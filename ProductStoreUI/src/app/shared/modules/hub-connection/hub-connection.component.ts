import { Component, WritableSignal, signal } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
import { HubUserStatus } from '../../models/HubUserStatus';

export const HUB_CONNECTION_URL = `${environment.api_base_url}/authstatus`;

@Component({
	selector: 'app-hub-connection',
	templateUrl: './hub-connection.component.html',
	styleUrl: './hub-connection.component.scss',
})
export class HubConnectionComponent {

	private hubConnectionBuilder!: HubConnection;

	hubUsers: WritableSignal<HubUserStatus[]> = signal([]);
	hubUsersList: HubUserStatus[] = [];

	ngOnInit(): void {
		this.establishHubConnection();
	}

	private establishHubConnection(): void {
		this.hubConnectionBuilder = new HubConnectionBuilder()
			.withUrl(HUB_CONNECTION_URL)
			.configureLogging(LogLevel.Information).build();

		this.hubConnectionBuilder.start().then(
			() => console.debug(`Connection initiated with hub server on ${HUB_CONNECTION_URL}`)
		).catch(() => console.error(`Error while connecting to hub server on ${HUB_CONNECTION_URL}`));

		this.hubConnectionBuilder.on('SendAuthStatusToUsers', (status: HubUserStatus) => {
			this.hubUsersList = this.updateStatus(this.hubUsersList, status);
			this.hubUsers.set(this.hubUsersList);
		});
	}

	private updateStatus(statusList: HubUserStatus[], newStatus: HubUserStatus) {
    const index = statusList.findIndex(x => x.name === newStatus.name);
    
    if (index !== -1) {
			statusList[index].isAuthenticated = newStatus.isAuthenticated;
    } else {
			statusList.push(newStatus);
    }

		return statusList;
	}
}