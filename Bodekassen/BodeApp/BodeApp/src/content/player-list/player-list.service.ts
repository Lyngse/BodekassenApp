import {Injectable} from '@angular/core';
import {Http, Headers, RequestOptions} from "@angular/http";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';

import { Player } from '../Model/player';

@Injectable()
export class PlayerListService {
  private headers = new Headers({'Content-Type': 'application/json'});
  options = new RequestOptions({ headers: this.headers });
  //apiUrl: string = 'http://bodeapp.azurewebsites.net/';
  apiUrl: string = 'http://localhost:59921/';

  constructor(private http: Http) {

  }

  getPlayers(teamId: number): Promise<Player[]> {
    const url = `${this.apiUrl}PublicApi/GetPlayers/?teamId=${teamId}`;
    return this.http
      .get(url)
      .toPromise()
      .then(response => response.json().Players)
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
