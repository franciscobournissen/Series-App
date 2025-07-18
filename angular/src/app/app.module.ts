import { CoreModule, provideAbpCore, withOptions } from '@abp/ng.core';
//import { provideAbpOAuth } from '@abp/ng.oauth';
import { provideSettingManagementConfig } from '@abp/ng.setting-management/config';
import { provideFeatureManagementConfig } from '@abp/ng.feature-management';
import { ThemeSharedModule, provideAbpThemeShared,} from '@abp/ng.theme.shared';
import { provideIdentityConfig } from '@abp/ng.identity/config';
import { provideAccountConfig } from '@abp/ng.account/config';
import { provideTenantManagementConfig } from '@abp/ng.tenant-management/config';
import { registerLocale } from '@abp/ng.core/locale';
import { ThemeBasicModule, provideThemeBasicConfig } from '@abp/ng.theme.basic';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SearchSeriesComponent } from './search-series/search-series.component';
import { NAVIGATE_TO_MANAGE_PROFILE } from '@abp/ng.core';


@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ThemeSharedModule,
    CoreModule,
    ThemeBasicModule,
    FormsModule,
    HttpClientModule,
    SearchSeriesComponent,
  ],
  providers: [
    APP_ROUTE_PROVIDER,
    provideAbpCore(
      withOptions({
        environment,
        registerLocaleFn: registerLocale(),
      }),
    ),
    {
      provide: NAVIGATE_TO_MANAGE_PROFILE,
      useValue: () => {
        // noop - navegación deshabilitada por ahora
        console.warn('NAVIGATE_TO_MANAGE_PROFILE no implementado aún');
      }
    },
    //provideAbpOAuth(),
    //provideIdentityConfig(),
    //provideSettingManagementConfig(),
    //provideFeatureManagementConfig(),
    //provideAccountConfig(),
    //provideTenantManagementConfig(),
    provideAbpThemeShared(),
    provideThemeBasicConfig(),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
