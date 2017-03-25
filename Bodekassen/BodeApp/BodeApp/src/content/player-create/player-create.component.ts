import {Component, ViewChild} from '@angular/core';
import { NavController } from 'ionic-angular';
import { PlayerCreateService } from "./player-create.service";

class PlayerCreateForm {
  constructor(public name: string = ""){

  }
}

@Component({
  selector: 'player-create',
  templateUrl: 'player-create.html',
  providers: [ PlayerCreateService ]
})
export class PlayerCreateComponent{
  model: PlayerCreateForm = new PlayerCreateForm();
  @ViewChild('f') form: any;

  constructor(public navCtrl: NavController, private playerCreateService: PlayerCreateService) {

  }

  onSubmit(name: string): void {
    this.playerCreateService.createPlayer(name, 1);
  }
}
