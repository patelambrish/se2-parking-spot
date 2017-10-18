import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { LoginComponent } from './components/login/login.component';
import {DataTableModule} from 'angular2-datatable';
import { routing, appRoutingProviders } from './app.routing';
import { SpotsComponent } from './components/spots/spots.component';
import { RegisterComponent } from './components/register/register.component';
import { DataService } from './services/data.service';
import { MyspotsComponent } from './components/myspots/myspots.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavigationComponent,
    LoginComponent,
    SpotsComponent,
    RegisterComponent,
    MyspotsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing,
    DataTableModule
  ],
  providers: [appRoutingProviders, DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
