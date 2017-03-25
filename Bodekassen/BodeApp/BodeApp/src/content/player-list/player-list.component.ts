import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { Player } from'../Model/player';
import { PlayerListService } from'./player-list.service';
import { PlayerCreateComponent } from'../player-create/player-create.component';

@Component({
  selector: 'player-list',
  templateUrl: 'player-list.html',
  providers: [PlayerListService]
})
export class PlayerListComponent {

  players: Player[];
  constructor(public navCtrl: NavController, private playerListService: PlayerListService) {

  }

  playerCreate = PlayerCreateComponent;

  ngOnInit() {
    this.getPlayers();
  }

  getPlayers(): void {
    this.playerListService
      .getPlayers(1)
      .then(players => this.players = players);
    console.log(this.players);
  }


  /*public getPlayers (id: number): Observable<Player[]> {
    return this.http.get('http://bodeapp.azurewebsites.net/' + 'PublicApi/GetPlayers/?teamId=${id}')
      .map(response => response.json())
      .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
  }*/



}
