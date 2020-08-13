import { TestBed } from '@angular/core/testing';

import { IdentityServerAdminService } from './identity-server-admin.service';

describe('IdentityServerAdminService', () => {
  let service: IdentityServerAdminService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IdentityServerAdminService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
