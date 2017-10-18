import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-myspots',
  templateUrl: './myspots.component.html',
  styleUrls: ['./myspots.component.css']
})
export class MyspotsComponent implements OnInit {
   public data: any[] = [
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '221', 'date': '06/23/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'}
  ];
  constructor() { }

  ngOnInit() {
  }

}
