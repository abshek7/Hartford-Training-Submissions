// import { Component, OnInit, OnDestroy } from '@angular/core';
// import { RouterOutlet } from '@angular/router';
// import { Subscription } from 'rxjs';
// import { CounterService } from './services/counter'; 
// import { CommonModule } from '@angular/common';

// @Component({
//    selector: 'app-root',
//   imports: [RouterOutlet,CommonModule],
//   templateUrl: './app.html',
//   styleUrl: './app.css'
// })
// export class App implements OnInit, OnDestroy {

//   manualCount = 0;
//   sub!: Subscription;

//   constructor(public counterService: CounterService) {}

//   ngOnInit() {
//     console.log('Component initialized');

//     // this.sub = this.counterService.counter$.subscribe(value => {
//     //   console.log('Manual subscription value:', value);
//     //   this.manualCount = value;
//     // });
//   }

//   ngOnDestroy() {
//     console.log('Component destroyed');
//     this.sub.unsubscribe();
//   }
// }




import { Component } from '@angular/core';
import { ChildComponent } from './components/child/child';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ChildComponent],
  templateUrl: 'app.html'
})

export class App {
  parentName = 'Angular 21';
  childMessage = '';

  receiveMessage(message: string) {
    this.childMessage = message;
  }
}
