import {Injectable} from '@angular/core';
import {Http, Headers, RequestOptions} from "@angular/http";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';

import { Finetype } from '../Model/finetype';

@Injectable()
export class FineTypeListService {
  private headers = new Headers({'Content-Type': 'application/json'});
  options = new RequestOptions({ headers: this.headers });
  apiUrl: string = 'http://bodeapp.azurewebsites.net/';
  //apiUrl: string = 'http://localhost:59921/';

  constructor(private http: Http) {

  }

  getFinetypes(teamId: number): Promise<Finetype[]> {
    const url = `${this.apiUrl}Api/ReadFineTypes/?teamId=${teamId}`;
    return this.http
      .get(url)
      .toPromise()
      .then(response => response.json().FineTypes)
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
