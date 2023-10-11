import { Component } from '@angular/core';
import { AuthService } from 'src/api/auth.service';
import { LoginIM } from 'src/model/loginIM';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private authService: AuthService) {
  }

  loginModel: LoginIM = {
    email: "hello@abv.bg",
    password: "string",
  }

  result: any = ""

  login(): void {
    this.authService.apiAuthLoginPost(this.loginModel).subscribe(
      (response) => {
        this.result = response;
        console.log(this.result);
      },
      (error) => {
        console.error("Login error:", error);
      }
    );
  }
}
