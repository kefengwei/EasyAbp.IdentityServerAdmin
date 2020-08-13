import { ModuleWithProviders, NgModule } from '@angular/core';
import { MY_PROJECT_NAME_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class IdentityServerAdminConfigModule {
  static forRoot(): ModuleWithProviders<IdentityServerAdminConfigModule> {
    return {
      ngModule: IdentityServerAdminConfigModule,
      providers: [MY_PROJECT_NAME_ROUTE_PROVIDERS],
    };
  }
}
