import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
 private data:string[]=[];
 
// we need to write getters and setters
getData():string[]{
return this.data;
}

addData(message:string):void{
  this.data.push(message);
}

}
