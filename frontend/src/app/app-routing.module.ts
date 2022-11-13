import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './notfound/component/not-found.component';

const routes: Routes = [
  { path: '', redirectTo: 'subscription/subscribe', pathMatch: 'full' },
  { path: 'subscription', loadChildren: () => import('./subscribe/subscribe.module').then((m) => m.SubscribeModule) },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
