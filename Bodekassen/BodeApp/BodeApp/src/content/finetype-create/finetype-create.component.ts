import {Component, ViewChild} from '@angular/core';
import { NavController } from 'ionic-angular';
import { FinetypeCreateService } from "./finetype-create.service";

class FinetypeCreateForm {
  constructor(public name: string = "",
              public defaultAmount: number = 0,
              public isCaseOfBeer: boolean = false,
              public isDeposit: boolean = false){

  }
}

@Component({
  selector: 'finetype-create',
  templateUrl: 'finetype-create.html',
  providers: [ FinetypeCreateService ]
})
export class FinetypeCreateComponent{
  model: FinetypeCreateForm = new FinetypeCreateForm();
  @ViewChild('f') form: any;

  constructor(public navCtrl: NavController, private finetypeCreateService: FinetypeCreateService) {

  }

  onSubmit(name: string, defaultAmount: number, isCaseOfBeer: boolean, isDeposit: boolean): void {
    this.finetypeCreateService.createFinetype(name, defaultAmount, 1, isCaseOfBeer, isDeposit);
  }
}
