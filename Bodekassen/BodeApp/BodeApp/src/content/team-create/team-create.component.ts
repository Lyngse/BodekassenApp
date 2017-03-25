import {Component, ViewChild} from '@angular/core';
import { NavController } from 'ionic-angular';
import {TeamCreateService} from "./team-create.service";

class TeamCreateForm {
  constructor(public name: string = "",
              public email: string = "",
              public password: string = ""){
  }
}

@Component({
  selector: 'team-create',
  templateUrl: 'team-create.html',
  providers: [TeamCreateService]
})
export class TeamCreateComponent{
  model: TeamCreateForm = new TeamCreateForm();
  @ViewChild('f') form: any;

  constructor(public navCtrl: NavController, private teamCreateService: TeamCreateService) {

  }

  onSubmit(name: string, email: string, password: string): void {
    this.teamCreateService.createTeam(name, email, password);
  }

}
