import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {
   //private apiurl: string = "http://angulartoo.azurewebsites.net/api";
   private apiurl:string = 'http://localhost:5000/api/';

  constructor(private _http: Http) { }

  testValues() {
    //let headers = new Headers({ 'Authorization': 'Bearer ' + this.authToken });
    let headers = new Headers({ 'Content-Type': 'application/json' });
    //headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });

    return this._http.get(this.apiurl+'Values', options)
      .map(res => res.json());
  }

  getSpots() {
    //let headers = new Headers({ 'Authorization': 'Bearer ' + this.authToken });
    let headers = new Headers({ 'Content-Type': 'application/json' });
    //headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });

    return this._http.get(this.apiurl + '/Spots', options)
      .map(res => res.json());
  }

  getLogin(email:string,mobile:string) {
    //let headers = new Headers({ 'Authorization': 'Bearer ' + this.authToken });
    let headers = new Headers({ 'Content-Type': 'application/json' });
    //headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });

    return this._http.get(this.apiurl + 'ShareAccounts?EmailAddress='+email+'&MobileNumber='+mobile, options)
      .map(res => res.json());
  }

  postRegistration(body:Object) {
    //let headers = new Headers({ 'Authorization': 'Bearer ' + this.authToken });
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this._http.post(this.apiurl + 'Account', JSON.stringify(body), options)
      .map(res => res.json());
  }

  activateAccount(id:string){
    //let headers = new Headers({ 'Authorization': 'Bearer ' + this.authToken });
    let headers = new Headers({ 'Content-Type': 'application/json' });
    //headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    return this._http.put(this.apiurl + 'Activate/'+id,null,options)
      .map(res => res.json());
  }

  putAccountUpdate(body:Object) {
    //let headers = new Headers({ 'Authorization': 'Bearer ' + this.authToken });
    let headers = new Headers({ 'Content-Type': 'application/json' });
    //headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    return this._http.put(this.apiurl + '/ShareAccounts/'+body["ID"], JSON.stringify(body), options)
      .map(res => res.json());
  }

   postSpot(body:Object) {
    //let headers = new Headers({ 'Authorization': 'Bearer ' + this.authToken });
    let headers = new Headers({ 'Content-Type': 'application/json' });
    //headers.append('Content-Type', 'application/json');
    let options = new RequestOptions({ headers: headers });
    return this._http.post(this.apiurl + '/Spots', JSON.stringify(body), options)
      .map(res => res.json());
  }

  localStore(body:Object){
    //store object information
    localStorage.setItem('spotShare', JSON.stringify(body));
    console.log('Stored Locally: '+JSON.stringify(body));
  }

  getStore(){
    //store object information
    let retrievedObject = localStorage.getItem('spotShare');
    return retrievedObject;
  }

  removeStore() {
    localStorage.removeItem('spotShare');
  }

}
