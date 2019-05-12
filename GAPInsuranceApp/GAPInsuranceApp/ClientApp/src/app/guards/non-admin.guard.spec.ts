import { TestBed, async, inject } from '@angular/core/testing';

import { NonAdminGuard } from './non-admin.guard';

describe('NonAdminGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NonAdminGuard]
    });
  });

  it('should ...', inject([NonAdminGuard], (guard: NonAdminGuard) => {
    expect(guard).toBeTruthy();
  }));
});
