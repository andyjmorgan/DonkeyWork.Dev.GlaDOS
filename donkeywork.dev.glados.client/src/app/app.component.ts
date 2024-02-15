import { HttpClient } from '@angular/common/http';
import {AfterViewInit, Component, ElementRef, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {TerminalService} from "primeng/terminal";
import {Subscription} from "rxjs";
import {MessageService} from "primeng/api";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [TerminalService, MessageService]
})
export class AppComponent implements OnInit, OnDestroy  {

  @ViewChild('audioElement', { static: false }) audioPlayer?: ElementRef;

  subscription: Subscription;
  public AudioTrackUrl: string = "";
  private ToastVisible = false;

  constructor(private terminalService: TerminalService, private messageService: MessageService) {
    this.subscription = this.terminalService.commandHandler.subscribe(async (command) => {
      let response = command === 'date' ? new Date().toDateString() : 'Unknown command: ' + command;
      this.ShowAudioToast();
      console.log("Sending response");
      this.terminalService.sendResponse(response);
      await this.sleep(1000);
      response = "12345";
      console.log("updating response");
    });
  }

  ngOnInit() {

  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  CloseAudioToast(){
    if(this.ToastVisible){
      this.ToastVisible = false;
      this.AudioTrackUrl = '';
      this.messageService.clear();
    }
  }

  sleep(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }

  audioEnded(){
    this.CloseAudioToast();
  }

  private IsPlayerVisible(): boolean{
    return this.ToastVisible && this.AudioTrackUrl.length > 0;
  }

  AudioCanPlayThrough(){
    console.log("Audio Can Play Through");
    this.audioPlayer?.nativeElement.play();
  }

  async ShowAudioToast() {
    if (!this.ToastVisible) {
      this.ToastVisible = true;
      this.AudioTrackUrl = 'https://i1.theportalwiki.net/img/d/d3/GLaDOS_sp_laser_redirect_intro_entry01.wav';
      this.messageService.add({
        key: 'confirm',
        sticky: true,
        severity: 'warn',
        summary: 'TestMessage',
        closable: false
      });

      await this.sleep(1000);
      this.audioPlayer?.nativeElement.play();
    }
  }

  title = 'donkeywork.dev.glados.client';
}
