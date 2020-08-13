import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { IdentityServerAdminComponent } from './components/identity-server-admin.component';
import { IdentityServerAdminRoutingModule } from './identity-server-admin-routing.module';

@NgModule({
  declarations: [IdentityServerAdminComponent],
  imports: [CoreModule, ThemeSharedModule, IdentityServerAdminRoutingModule],
  exports: [IdentityServerAdminComponent],
})
export class IdentityServerAdminModule {
  static forChild(): ModuleWithProviders<IdentityServerAdminModule> {
    return {
      ngModule: IdentityServerAdminModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<IdentityServerAdminModule> {
    return new LazyModuleFactory(IdentityServerAdminModule.forChild());
  }
}
