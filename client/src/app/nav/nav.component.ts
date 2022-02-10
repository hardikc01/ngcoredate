import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model : any = {};



  constructor(public accountService : AccountService, private route : Router,
              private toastrService : ToastrService) { }

  ngOnInit(): void {
    
  }

  login(){
    this.accountService.login(this.model).subscribe(response => {
        //this.loggedIn = true;
        this.route.navigateByUrl('/lists');
      }, error => {
        this.toastrService.error(error.error);
        console.log(error);
  });
  }

  logout(){
     this.accountService.logout();
     this.route.navigateByUrl('/');
      //this.loggedIn = false;
  }

  // setCurrentUser(){
  //   this.accountService.currentUser$.subscribe(user =>
  //     this.loggedIn = !!user,
  //     error =>{
  //       console.log(error);
  //     },
  //     () =>
  //     console.log('c')
  //     )
  // }
}
