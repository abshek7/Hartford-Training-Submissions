import { Injectable } from '@angular/core';
import { Observable, interval, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CounterService {

  // Emits a number every 1 second
  counter$: Observable<number> = interval(1000).pipe(
    map(value => value + 1)
  );

}
