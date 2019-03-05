import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'; 
import { FormsModule, ReactiveFormsModule} from '@angular/forms'; 
import { BsDropdownModule,TooltipModule,ModalModule} from 'ngx-bootstrap';

import { EscolaService } from './_services/escola.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EscolasComponent } from './escolas/escolas.component';
import { HttpClient } from 'selenium-webdriver/http';
import { NavComponent } from './nav/nav.component';


@NgModule({
   declarations: [
      AppComponent,
      EscolasComponent,
      NavComponent
   ],
   imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule
   ],
   providers: [
      EscolaService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
