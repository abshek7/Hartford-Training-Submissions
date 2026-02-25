import { TestBed } from '@angular/core/testing';

import { ReaderDashboard } from './reader-dashboard';

describe('ReaderDashboard', () => {
  let service: ReaderDashboard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReaderDashboard);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
