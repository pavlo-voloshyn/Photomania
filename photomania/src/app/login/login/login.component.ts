import { TokenService } from './../../services/token.service';
import { UserService } from './../../services/user.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  username: string = "";
  password: string = "";

  message: string = ''
  isError = false;

  constructor(private router: Router, private userService: UserService,
    private tokenService: TokenService) { }

  ngOnInit(): void {
  }

  onClickLogup(): void {
    this.router.navigate(['logup'])
  }

  onClickLogin() {
    this.isError = false;
    this.userService.login(this.username, this.password).subscribe(res => {
      this.tokenService.setToken(res.token);
      this.tokenService.getRole();
      this.router.navigate(['']);
    }, err => {
      this.isError = true;
      this.message = err.error
      console.log(err)
    })
  }
}
