import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginFormComponent } from './shared/components';
import { AuthGuardService } from './shared/services';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { DisplayDataComponent } from './pages/display-data/display-data.component';
import { DxDataGridModule, DxFormModule, DxButtonModule } from 'devextreme-angular';
import { UsersComponent } from './pages/users/users.component';
import { TestComponent } from './pages/test/test.component';
import { DevicecategoriesComponent } from './pages/devicecategories/devicecategories.component';
import { DevicesComponent } from './pages/devices/devices.component';

const routes: Routes = [
  {
    path: 'display-data',
    component: DisplayDataComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'login-form',
    component: LoginFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'users',
    component: UsersComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'devicecategories',
    component: DevicecategoriesComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'devices',
    component: DevicesComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'test',
    component: TestComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: '**',
    redirectTo: 'home',
    canActivate: [ AuthGuardService ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), DxDataGridModule, DxFormModule, DxButtonModule],
  providers: [AuthGuardService],
  exports: [RouterModule],
  declarations: [HomeComponent, ProfileComponent, DisplayDataComponent, UsersComponent, TestComponent, DevicecategoriesComponent, DevicesComponent]
})
export class AppRoutingModule { }
