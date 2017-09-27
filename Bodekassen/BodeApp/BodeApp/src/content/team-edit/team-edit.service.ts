import {Injectable} from '@angular/core';
import {Http, Headers, RequestOptions} from "@angular/http";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';
import { Team } from '../Model/team';

@Injectable()
export class TeamEditService{

  private headers = new Headers({'Content-Type': 'application/json'});
  options = new RequestOptions({ headers: this.headers });
  apiUrl: string = "http://bodeapp.azurewebsites.net/";
  //apiUrl: string = 'http://localhost:59921/';

  constructor(private http: Http) {

  }

  getTeam(id: number): Observable<Team> {
    return this.http.get("http://bodeapp.azurewebsites.net/" + 'PublicAPI/GetTeam/' + id)
      .map(response => response.json().data as Team);
  }

  updateTeam(teamId: number, name: string, email: string, password: string): Promise<Team> {
    console.log(name, email, password);
    const url = `${this.apiUrl}Api/UpdateTeam/?teamId=${teamId}`;
    return this.http
      .post(url, JSON.stringify({teamId: teamId, name: name, email: email, password: password}), this.options)
      .toPromise()
      .then(() => console.log("Edited"))
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
