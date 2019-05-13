import { TestBed, async, inject } from '@angular/core/testing';

import { NonAddGuard } from './non-add.guard';

describe('NonAddGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NonAddGuard]
    });
  });

  it('should ...', inject([NonAddGuard], (guard: NonAddGuard) => {
    expect(guard).toBeTruthy();
  }));
});
