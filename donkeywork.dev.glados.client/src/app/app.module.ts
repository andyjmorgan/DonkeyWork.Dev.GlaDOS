import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import {TerminalModule} from "primeng/terminal";
import {CardModule} from "primeng/card";
import {ToastModule} from "primeng/toast";
import {Button} from "primeng/button";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    TerminalModule,
    CardModule,
    ToastModule,
    NoopAnimationsModule,
    BrowserAnimationsModule,
  ],
  providers: [TerminalModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
