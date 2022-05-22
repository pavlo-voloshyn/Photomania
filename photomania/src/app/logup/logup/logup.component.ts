import { UserService } from './../../services/user.service';
import { UserRegister } from './../../models/user-register.interface';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logup',
  templateUrl: './logup.component.html',
  styleUrls: ['./logup.component.scss']
})
export class LogupComponent implements OnInit {
  user: UserRegister = {
    firstName: '',
    lastName: '',
    userName: '',
    password: ''
  }

  message: string = ''
  isError = false;

  constructor( private router: Router,
    private userService: UserService) { }

  ngOnInit(): void {
  }


  onClickLogup() {
    this.isError = false;
    this.userService.register(this.user).subscribe(res => {
      this.router.navigate(['login'])
    }, err => {
      this.isError = true;
      this.message = err.error
      console.log(err);
    });
  }

  onClickLogin(): void {
    this.router.navigate(['login'])
  }
}
