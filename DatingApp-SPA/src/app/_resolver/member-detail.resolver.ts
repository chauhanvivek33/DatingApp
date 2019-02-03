import { Injectable } from "@angular/core";
import { Resolve, Router, RouterStateSnapshot, ActivatedRouteSnapshot } from "@angular/router";
import { User } from "../_model/User";
import { UserService } from "../_services/user.service";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable()

export class MemberDetailResolver implements Resolve<User>
{
    constructor(private userService:UserService,private alertify:AlertifyService,private router:Router){}

    resolve(route : ActivatedRouteSnapshot):Observable<User>
    {
       return this.userService.getuser(route.params['id']).pipe(
           catchError(error=>{
               this.alertify.error("Problem Retreving Data");
               this.router.navigate(['/members']);
               return of(null);
           })
       );
    }

}