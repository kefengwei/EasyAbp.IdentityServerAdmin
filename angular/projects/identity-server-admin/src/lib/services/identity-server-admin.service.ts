import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class IdentityServerAdminService {
  apiName = 'IdentityServerAdmin';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/IdentityServerAdmin/sample' },
      { apiName: this.apiName }
    );
  }
}
