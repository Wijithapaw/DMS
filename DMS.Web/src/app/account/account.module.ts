import { NgModule } from '@angular/core';

import { LoginComponent } from './login/login.component';
import { AccountRoutingModule } from './account-routing.module'
import { SharedModule } from '../shared/shared.module';
import { AccountService } from './services/account.service';

@NgModule({
  imports: [
    AccountRoutingModule,
    SharedModule
  ],
  declarations: [
    LoginComponent
  ],
  providers: [
    AccountService
  ]
})
export class AccountModule { }
