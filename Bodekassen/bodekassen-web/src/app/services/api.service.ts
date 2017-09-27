import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from "@angular/http";
import { Observable, BehaviorSubject } from 'rxjs/Rx';
import 'rxjs/Rx';
import * as moment from 'moment';

@Injectable()
export class ApiService {

  private headers = new Headers({'Content-Type': 'application/json'});
  options = new RequestOptions({ headers: this.headers });
  
  private url = "https://tabl.azurewebsites.net/api/";
  //public user: BehaviorSubject<User> = new BehaviorSubject(new User);


  constructor(private http: Http) { 
  }


  private handleError(error: any): Promise<any>{
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error || 'Server error')
    }

}
