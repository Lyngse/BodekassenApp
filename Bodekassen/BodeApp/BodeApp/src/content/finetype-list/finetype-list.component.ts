import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { FineTypeListService } from'./finetype-list.service';
import { Finetype } from "../Model/finetype";
import { FinetypeCreateComponent } from'../finetype-create/finetype-create.component';


@Component({
  selector: 'finetype-list',
  templateUrl: 'finetype-list.html',
  providers: [FineTypeListService]
})
export class FinetypeListComponent {
  finetypeCreate = FinetypeCreateComponent;
  finetypes: Finetype[];
  constructor(public navCtrl: NavController, private fineTypeListService: FineTypeListService) {

  }

  ngOnInit() {
    this.getFinetypes();
  }

  getFinetypes(): void {
    this.fineTypeListService
      .getFinetypes(1)
      .then(FineTypes => this.finetypes = FineTypes);
    console.log(this.finetypes);
  }


  /*public getPlayers (id: number): Observable<Player[]> {
   return this.http.get('http://bodeapp.azurewebsites.net/' + 'PublicApi/GetPlayers/?teamId=${id}')
   .map(response => response.json())
   .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
   }*/



}
