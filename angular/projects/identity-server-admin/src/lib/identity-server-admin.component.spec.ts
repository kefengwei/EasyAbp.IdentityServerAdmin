import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IdentityServerAdminComponent } from './identity-server-admin.component';

describe('IdentityServerAdminComponent', () => {
  let component: IdentityServerAdminComponent;
  let fixture: ComponentFixture<IdentityServerAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IdentityServerAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IdentityServerAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
