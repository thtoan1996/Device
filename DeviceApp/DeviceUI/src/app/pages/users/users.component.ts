import { NgModule, Component, enableProdMode, ChangeDetectionStrategy } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { DxDataGridModule } from 'devextreme-angular';
import * as AspNetData from "devextreme-aspnet-data-nojquery";
import { environment } from 'src/environments/environment';

if(!/localhost/.test(document.location.host)) {
    enableProdMode();
}

@Component({
    styleUrls: ['./users.component.css'],
    selector: 'app-users',
    templateUrl: './users.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class UsersComponent {
    dataSource: any;
    url: string;

    constructor() {
        this.url = environment.apiUrl;
        
        this.dataSource = AspNetData.createStore({
            key: "uId",
            loadUrl: `${this.url}/users`,
            insertUrl: `${this.url}/users`,
            updateUrl: `${this.url}/users`,
            deleteUrl: `${this.url}/users`,
            onBeforeSend: function (method, ajaxOptions) {
                ajaxOptions.xhrFields = { withCredentials: true };
                if (ajaxOptions.data) {

                    switch (method) {
                        case "GET":
                            break;
                        case "update":
                            ajaxOptions.url += "?id=" + ajaxOptions.data.key + "&model=" + ajaxOptions.data.values;                            
                            break;
                        case "insert":
                            ajaxOptions.url += "?model=" + ajaxOptions.data.values;
                            break;
                        case "delete":
                            ajaxOptions.url += "/" + ajaxOptions.data.key;
                            break;
                    }
                }
            },
        });
    }
   
}