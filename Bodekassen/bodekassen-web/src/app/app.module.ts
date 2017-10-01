import { BrowserModule } from '@angular/platform-browser';
import { NgModule,  } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FacebookModule } from 'ngx-facebook';

import {
  MdButtonModule,
  MdCheckboxModule,
  MdToolbarModule,
  MdSidenavModule,
  MdMenuModule} from '@angular/material';

import { ApiService } from './services/api.service';
import { PublicApiService } from './services/publicApi.service';
import { UtilService } from './services/util.service';
import { FacebookService } from 'ngx-facebook';

import { AppComponent } from './app.component';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { FooterComponent } from './shared/footer/footer.component';
import { HeaderComponent } from './shared/header/header.component';

const appRoutes: Routes = [
  { path: '', redirectTo: 'frontpage', pathMatch: 'full'},
  { path: 'frontpage', component: FrontpageComponent },
  { path: '**', redirectTo: 'frontpage' }
]

@NgModule({
  declarations: [
    AppComponent,
    FrontpageComponent,
    FooterComponent,
    HeaderComponent,
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    FacebookModule.forRoot(),
    MdButtonModule,
    MdSidenavModule,
    MdToolbarModule,
    MdMenuModule
  ],
  providers: [FacebookService, ApiService, UtilService, PublicApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
