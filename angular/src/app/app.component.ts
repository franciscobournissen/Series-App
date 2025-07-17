// src/app/app.component.ts
import { Component } from '@angular/core';

@Component({
  standalone: false, // 👈 asegurate de que esto esté así, o simplemente borralo
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <router-outlet></router-outlet>
  `,
})
export class AppComponent {}
