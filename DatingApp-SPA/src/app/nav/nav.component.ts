import { Component, OnInit } from "@angular/core";
import { AuthService } from "../_services/auth.service";
import { AlertifyService } from "../_services/alertify.service";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.css"]
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(private auth: AuthService,private alertify:AlertifyService) {}

  ngOnInit() {}

  login() {
    this.auth.login(this.model).subscribe(
      next => {
        this.alertify.success("User logged in successfully");
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  loggedIn() {
   return this.auth.loggedIn();
  }

  loggedOut() {
    localStorage.removeItem("token");
    this.alertify.message("User logged Out");
  }
}
