import { TestBed } from '@angular/core/testing';

import { AuthorDashboardService } from './author-dashboard';

describe('Author', () => {
  let service: AuthorDashboardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthorDashboardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
