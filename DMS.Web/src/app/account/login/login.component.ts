import { Component, OnInit } from '@angular/core';

import { LoginDto } from '../models/login-dto'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginData: LoginDto = new LoginDto();

  constructor() { }

  ngOnInit() {
  }

  public login(): void {
    console.log(this.loginData);
  }

}
