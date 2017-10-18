import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DataService } from '../../services/data.service';
import { Spot } from './Model/spot.model';
import { MyspotsComponent } from '../myspots/myspots.component';

@Component({
  selector: 'app-spots',
  templateUrl: './spots.component.html',
  styleUrls: ['./spots.component.css']
})
export class SpotsComponent implements OnInit {
  public months: any[] = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
  public days: any[] = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19',
  '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30', '31'];
  public years: any[] = ['2017', '2018', '2019', '2020', '2021', '2022', '2023'];
  public post = {
    EmailAddress: '',
    Mobile: '',
    Spot: '',
    sMonth: '',
    sDay: '',
    sYear: '',
    eMonth: '',
    eDay: '',
    eYear: ''
  };
  constructor(private _dataService: DataService) { }

  ngOnInit() {
    //check if a share is already active and assigned, if already shared disable the ability to submit the form.
    //Provide an indication

    var d = new Date();
    var year = d.getFullYear();
    var day = d.getDate();
    var month = this.months[d.getMonth()];
    this.post.EmailAddress = 'nicketrower@se2.com';
    this.post.Mobile = '7852508529';
    this.post.Spot = '222';
    this.post.sDay = day.toString();
    this.post.sMonth = month;
    this.post.sYear = year.toString();
    this.post.eDay = day.toString();
    this.post.eMonth = month;
    this.post.eYear = year.toString();

    console.log(month+"/"+day+"/"+year);
  }

  share(form: NgForm){
    let sdate = this.months.indexOf(this.post.sMonth) + 1;
    let edate = this.months.indexOf(this.post.eMonth) + 1;
    let startDate = sdate+"-"+this.post.sDay+"-"+this.post.sYear;
    let endDate = sdate+"-"+this.post.eDay+"-"+this.post.eYear;

     let payload = new Spot();
      payload.AccountID = 1;
      payload.Spot = this.post.Spot;
      payload.StartDate = startDate;
      payload.EndDate = endDate;

     this._dataService.postSpot(payload).subscribe(res => {
         console.log(res);
    });

  }
}
