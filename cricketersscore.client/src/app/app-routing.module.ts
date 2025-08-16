
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CricketersComponent } from './cricketers/cricketers.component';
import { AboutComponent } from './about/about.component';

const routes: Routes = [
  { path: '', redirectTo: '/cricketers', pathMatch: 'full' }, // default
  { path: 'cricketers', component: CricketersComponent },
  { path: 'about', component: AboutComponent },
  { path: '**', redirectTo: '/cricketers' } // fallback
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
