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
  selector: 'app-devicecategories',
  templateUrl: './devicecategories.component.html',
  styleUrls: ['./devicecategories.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DevicecategoriesComponent {
  dataSource: any;
  url: string;

  constructor() {
      this.url = environment.apiUrl;
      
      this.dataSource = AspNetData.createStore({
          key: "dcId",
          loadUrl: `${this.url}/devicecategories`,
          insertUrl: `${this.url}/devicecategories`,
          updateUrl: `${this.url}/devicecategories`,
          deleteUrl: `${this.url}/devicecategories`,
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