import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SubscriberPageComponent } from './components/subscriber-page/subscriber-page.component';
import { UnsubscribePageComponent } from './components/unsubscribe-page/unsubscribe-page.component';

const routes: Routes = [
  { path: 'subscribe', component: SubscriberPageComponent },
  { path: 'unsubscribe/:id', component: UnsubscribePageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SubscribeRoutingModule { }
