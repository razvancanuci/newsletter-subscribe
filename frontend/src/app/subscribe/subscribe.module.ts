import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SubscribeRoutingModule } from './subscribe-routing.module';
import { SubscriberPageComponent } from './components/subscriber-page/subscriber-page.component';
import { SubscriberFormComponent } from './components/subscriber-page/subscriber-form/subscriber-form.component';
import { ConfirmSubscriptionComponent } from './components/subscriber-page/confirm-subscription/confirm-subscription.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UnsubscribePageComponent } from './components/unsubscribe-page/unsubscribe-page.component';
import { UnsubscribeFormComponent } from './components/unsubscribe-page/unsubscribe-form/unsubscribe-form.component';
import { UnsubscribeIdComponent } from './components/unsubscribe-page/unsubscribe-id/unsubscribe-id.component';
import { ConfirmUnsubscribeComponent } from './components/unsubscribe-page/confirm-unsubscribe/confirm-unsubscribe.component';


@NgModule({
  declarations: [
    SubscriberPageComponent,
    SubscriberFormComponent,
    ConfirmSubscriptionComponent,
    UnsubscribePageComponent,
    UnsubscribeFormComponent,
    UnsubscribeIdComponent,
    ConfirmUnsubscribeComponent
  ],
  imports: [
    CommonModule,
    SubscribeRoutingModule,
    ReactiveFormsModule
  ]
})
export class SubscribeModule { }
