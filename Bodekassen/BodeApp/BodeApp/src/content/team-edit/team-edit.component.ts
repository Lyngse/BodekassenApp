import {Component, NgModule, OnInit, ViewChild} from '@angular/core';

import { FormsModule, FormControl } from '@angular/forms';
import { NavController } from 'ionic-angular';
import {Http, Response, Headers, RequestOptions} from "@angular/http";

import { TeamEditService } from './team-edit.service';
import { Team } from '../Model/team';
import {Observable} from "rxjs";
class TeamCreateForm {
  constructor(public name: string = "",
              public email: string = "",
              public password: string = ""){
  }
}

@Component({
  selector: 'team-edit',
  templateUrl: 'team-edit.html',
  providers: [TeamEditService]
})
export class TeamEditComponent{
  model: TeamCreateForm = new TeamCreateForm();
  @ViewChild('f') form: any;
  team: any = {};

  constructor(public navCtrl: NavController, private teamEditService: TeamEditService, private http: Http) {

  }
  onSave(teamId: number, name: string, email: string, password: string): void {
    this.teamEditService.updateTeam(teamId, name, email, password);
  }


}
