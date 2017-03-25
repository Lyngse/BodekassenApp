import {Injectable} from '@angular/core';
import {Http, Headers, RequestOptions} from "@angular/http";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';
import { Team } from '../Model/team';

@Injectable()
export class TeamCreateService {

  private headers = new Headers({'Content-Type': 'application/json'});
  options = new RequestOptions({headers: this.headers});
  apiUrl: string = 'http://bodeapp.azurewebsites.net/';


  constructor(private http: Http) {

  }

  createTeam(name: string, email: string, password: string): Promise<Team> {
    console.log(name, email, password);
    return this.http
      .post(this.apiUrl + 'api/CreateTeam/', JSON.stringify({name:  name, email: email, password: password}), this.options)
      .toPromise()
      .then((res) => res.json().data)
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
