import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { LoginDto } from '../models/login-dto'
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginData: LoginDto = new LoginDto();
  errorMessage: string = '';
  returnUrl: string = '';

  constructor(private accountService: AccountService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.forEach((params: Params) => {
      if (params['returnUrl'] != null) {
        this.returnUrl = params['returnUrl'];
      }
    });
  }

  public login(): void {
    this.accountService.login(this.loginData)
      .then(() => {
        let link = [this.returnUrl]
        this.router.navigate(link);
      })
      .catch((response) => {
        this.errorMessage = response.error.json().error;
      });
  }

  public clearError() {
    this.errorMessage = "";
  }
}
