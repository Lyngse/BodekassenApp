import { Injectable } from '@angular/core';
import { FacebookService, InitParams, LoginResponse, LoginStatus, LoginOptions } from 'ngx-facebook';
import { Http, Headers, RequestOptions } from "@angular/http";
import { Observable, BehaviorSubject } from 'rxjs/Rx';
import 'rxjs/Rx';
import * as moment from 'moment';

@Injectable()
export class PublicApiService {

  private headers = new Headers({'Content-Type': 'application/json'});
  options = new RequestOptions({ headers: this.headers });
  
  private url = "https://tabl.azurewebsites.net/api/";
  //public user: BehaviorSubject<User> = new BehaviorSubject(new User);


  constructor(private fb: FacebookService, private http: Http) { 
    let initParams: InitParams = {
      appId: '372337469632170',
      xfbml: true,
      cookie: true,
      version: 'v2.8'
    };
 
    fb.init(initParams);
  }

  /*updateUser(): Promise<any>{
    return this.fb.getLoginStatus()
      .then((res) => {
        if(res.authResponse)
          return this.facebookLogin(res.authResponse.userID);
        else
          return false;
      })
  }

  logout(): Promise<any>{
    return this.fb.logout()
      .then(res => this.user.next(new User))
      .catch(this.handleError);
  }

  login(): Promise<any>{
      return this.fb.getLoginStatus()
      .then((res) => {
        if(res.authResponse)
          return this.facebookLogin(res.authResponse.userID);
        else{
          const options: LoginOptions = {
            scope: 'public_profile,email',
            return_scopes: true
          };
          return this.fb.login(options)
          .then((res) => {
            if(res.authResponse)
              return this.facebookLogin(res.authResponse.userID);
            else
              return Promise.reject("error logging in");
          })
          .catch(this.handleError);  
        }
      })
      .catch(this.handleError);
  }


  facebookLogin(facebookId: string): Promise<any>{
    return this.http
      .post(this.url + 'FacebookLogin', JSON.stringify({apiKey: this.apiKey, facebookToken: facebookId}), this.options)
      .toPromise()
      .then((res) => {let result = res.json(); result.facebookId = facebookId; this.user.next(result)})
      .catch((err) => {
        if(err.status === 406){
          return this.fb.api('/me?fields=id,last_name,first_name,email')
            .then((res) => {
              return this.facebookRegister(res.id, res.first_name, res.last_name, res.email);
            })
            .catch(this.handleError);
        }else{
          return this.handleError(err);
        }
      });
  }

  facebookRegister(facebookId: string, firstName: string, lastName: string, email: string): Promise<any>{
    var res = {
      apiKey: this.apiKey,
      facebookToken: facebookId,
      firstname: firstName,
      lastname: lastName,
      email: email
    }
    return this.http
      .post(this.url + 'facebookregister', JSON.stringify(res), this.options)
      .toPromise()
      .then(res => {this.user = res.json(); return res.json()})
      .catch(this.handleError)
  }*/

  private handleError(error: any): Promise<any>{
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error || 'Server error')
    }

}
