import { NgModule, ErrorHandler } from '@angular/core';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import {  HttpModule } from '@angular/http';
import { FormsModule } from "@angular/forms";

/* Services */
import { TeamEditService } from "../content/team-edit/team-edit.service";
import { PlayerListService } from '../content/player-list/player-list.service';

/* Contents */
import { MyApp } from './app.component';
import { Page1 } from '../pages/page1/page1';
import { Page2 } from '../pages/page2/page2';
import { PlayerListComponent } from '../content/player-list/player-list.component';
import { TeamCreateComponent } from "../content/team-create/team-create.component";
import { TeamEditComponent } from "../content/team-edit/team-edit.component";
import {PlayerCreateComponent} from "../content/player-create/player-create.component";
import {FinetypeCreateComponent} from "../content/finetype-create/finetype-create.component";
import {FinetypeListComponent} from "../content/finetype-list/finetype-list.component";


@NgModule({
  declarations: [
    MyApp,
    FinetypeCreateComponent,
    FinetypeListComponent,
    PlayerCreateComponent,
    PlayerListComponent,
    TeamCreateComponent,
    TeamEditComponent,
    Page1,
    Page2,
  ],
  imports: [
    IonicModule.forRoot(MyApp),
    HttpModule,
    FormsModule,
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    FinetypeCreateComponent,
    FinetypeListComponent,
    PlayerCreateComponent,
    PlayerListComponent,
    TeamCreateComponent,
    TeamEditComponent,
    Page1,
    Page2
  ],
  providers: [{
    provide: ErrorHandler,
    useClass: IonicErrorHandler
  }],

})
export class AppModule {}
