import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// import { CommonModule } from '@angular/common';
// import { StatusClassPipe } from './pipes/status-button-pipe';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet
    // CommonModule,
    // StatusClassPipe
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  // orders = [
  //   { id: 1, statusId: 1 },
  //   { id: 2, statusId: 2 },
  //   { id: 3, statusId: 3 },
  //   { id: 4, statusId: 4 },
  //   { id: 5, statusId: 5 }
  // ];
}
