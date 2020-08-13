import { Component, OnInit } from '@angular/core';
import { IdentityServerAdminService } from '../services/identity-server-admin.service';

@Component({
  selector: 'lib-identity-server-admin',
  template: ` <p>identity-server-admin works!</p> `,
  styles: [],
})
export class IdentityServerAdminComponent implements OnInit {
  constructor(private service: IdentityServerAdminService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
