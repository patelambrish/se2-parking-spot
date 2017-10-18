import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public data: any[] = [
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '221', 'date': '06/23/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'},
  {'spot': '222', 'date': '06/22/2017', 'id': '23'}
  ];
  constructor() { }

  ngOnInit() {
  }

  reserve(id: string) {
    console.log(id);
  }
}
