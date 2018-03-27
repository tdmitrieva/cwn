import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { User } from "../../models/user";
import { LoginService } from "../../services/login-service";
import { Router } from '@angular/router';
import { DataStorage } from "../../models/data-storage";

@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  emailControl = new FormControl();

  user: User;

  constructor(private loginService: LoginService,
              private router: Router,
              private storageModel: DataStorage) {
    this.user = new User();
  }

  ngOnInit() { }

  public onSubmitClick() {
    this.loginService.getUser(this.user.Email).subscribe((result) => {
      if (result != null) {
        this.user = result;
        this.storageModel.currentUser = this.user;
        this.router.navigate(['/finances']);
      }
      else {
        this.emailControl.setErrors({'usernotexists': true})
      }
    });
  }

}
