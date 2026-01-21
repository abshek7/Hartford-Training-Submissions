import { Component, inject, ChangeDetectorRef } from '@angular/core';
import { CricketerService } from '../../services/cricketer';
import { Cricketer } from '../../models/cricketer';

@Component({
  selector: 'app-cricketer',
  imports: [],
  templateUrl: './cricketer.html',
  styleUrls: ['./cricketer.css'],
})
export class CricketerComponent {
  private cricketerService = inject(CricketerService);
  private cdr = inject(ChangeDetectorRef);

  cricketers: Cricketer[] = [];

  ngOnInit() {
    console.log('Fetching cricketers...');
    this.cricketerService.getAllCricketers().subscribe({
      next: (data) => {
        console.log('Data received:', data);
        this.cricketers = data;
        console.log('Cricketers array:', this.cricketers);
        this.cdr.detectChanges(); // Manually trigger change detection
      },
      error: (error) => {
        console.error('Error fetching cricketers:', error);
      }
    });
  }
}