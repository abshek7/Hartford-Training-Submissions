import { Component } from '@angular/core';

@Component({
  selector: 'app-insurance-profiles',
  imports: [],
  templateUrl: './insurance-profiles.html',
  styleUrl: './insurance-profiles.css',
})
export class InsuranceProfiles {
insuranceProfiles = [
    { name: 'Home', image: 'assets/image.png' },
    { name: 'Health', image: 'assets/image.png' },
    { name: 'Business', image: 'assets/image.png' },
    { name: 'Life', image: 'assets/image.png' }
  ];
}
