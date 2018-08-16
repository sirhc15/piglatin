import { Component, OnInit, Output } from '@angular/core';
import { Http } from '@angular/http'
import { EventEmitter } from '../../node_modules/protractor';

@Component({
   selector: 'app-root',
   templateUrl: './app.component.html',
   styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
   public englishText: string;
   constructor(private _httpService: Http) { 
       this.englishText = "";
   }
   apiValues: string[] = [];
   ngOnInit() {
      this._httpService.get('/api/values').subscribe(values => {
         this.apiValues = values.json() as string[];
      });
   }

   submitText(inputText: string): void{
       this.englishText = inputText;
       console.log(this.englishText);
   }
}