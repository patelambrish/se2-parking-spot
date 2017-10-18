import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private _dataservice: DataService) { }

  ngOnInit() {
  }

  login(form: NgForm){
     this._dataservice.getLogin(form.value.email,form.value.mobile).subscribe((res) => {
       console.log(res);
    },
      (err) => {
        console.log(JSON.parse(err._body).Message);
      });
  }

}
