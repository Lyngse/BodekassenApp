import {Component, ViewChild} from '@angular/core';
import { NavController } from 'ionic-angular';
import { FinetypeCreateService } from "./finetype-create.service";

class FinetypeCreateForm {
  constructor(public name: string = ""){

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

  onSubmit(name: string): void {
    this.finetypeCreateService.createFinetype(name, 1);
  }
}
