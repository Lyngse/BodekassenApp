import {Injectable} from '@angular/core';
import {Http, Headers, RequestOptions} from "@angular/http";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';
import { Player } from '../Model/player';

@Injectable()
export class PlayerCreateService {

  private headers = new Headers({'Content-Type': 'application/json'});
  options = new RequestOptions({headers: this.headers});
  apiUrl: string = 'http://bodeapp.azurewebsites.net/';

  constructor(private http: Http) {

  }

  createPlayer(name: string, teamId: number): Promise<Player> {
    return this.http
      .post(this.apiUrl + 'api/CreatePlayer/', JSON.stringify({name:  name, teamId: teamId}), this.options)
      .toPromise()
      .then((res) => res.json().data)
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
