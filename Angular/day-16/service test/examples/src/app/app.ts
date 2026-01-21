import { Component } from '@angular/core';
import { Calculator } from './services/calculator';
import { FormsModule } from '@angular/forms';
 

import { MessageService } from './services/message-service';

@Component({
  imports:[FormsModule],
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  // ans: number[] = [];

  // constructor(private calculator: Calculator) {
  //   this.ans.push(this.calculator.add(7, 7));
  //   this.ans.push(this.calculator.subtract(10, 7));
  //   this.ans.push(this.calculator.multiply(6, 9));
  //     this.ans.push(this.calculator.divide(6, 9));
  // }

  message = '';
  messages: string[] = [];

  constructor(private messageService: MessageService) {
    // load existing messages
    this.messages = this.messageService.getData();
  }

  addMessage() {
    if (this.message.trim()) {
      this.messageService.addData(this.message);
      this.message = '';
    }
  }

}
