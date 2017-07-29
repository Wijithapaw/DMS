import { NgModule } from '@angular/core';

import { LoginComponent } from './login/login.component';
import { AccountRoutingModule } from './account-routing.module'
import { SharedModule } from '../shared/shared.module';
 
@NgModule({
  imports: [
    AccountRoutingModule,
    SharedModule
  ],
  declarations: [LoginComponent]
})
export class AccountModule { }
