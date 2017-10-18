import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public msg: String;
  public success: Boolean = null;
  public loginlink: Boolean = false;

  constructor(private _dataservice: DataService) { }
  ngOnInit() {
  }

  register(registerForm:NgForm){

    this._dataservice.postRegistration(registerForm.value).subscribe((res) => {
       this.msg = res.message;
       this.success = res.success;
    },
      (err) => {
        console.log(JSON.parse(err._body).Message);
        this.msg = JSON.parse(err._body).Message;
      });
  }

}
