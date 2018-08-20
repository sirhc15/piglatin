import { Component, OnInit, Output } from '@angular/core';
import { Http } from '@angular/http'
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

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
   pigLatinValues: string[] = [];
   ngOnInit() {
      this._httpService.get('/api/values').subscribe(values => {
         this.apiValues = values.json() as string[];
      });
   }

   submitEnglishText(inputText: string): void{
       this.englishText = inputText;
    //    this._httpService.post('/api/values', inputText, httpOptions).subscribe(values => {
    //        this.pigLatinValues = values.json() as string[];
    //    });
   }

}