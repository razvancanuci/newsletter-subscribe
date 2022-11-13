import { Injectable } from '@angular/core';
import { Subscriber } from '../models/models';
import { SubscriberApiService } from './subscriber-api.service';

@Injectable({
  providedIn: 'root'
})
export class SubscriberService {

  constructor(private _subscriberApiService: SubscriberApiService) { }

  getSubscribers() {
    return this._subscriberApiService.get();
  }

  getStats() {
    return this._subscriberApiService.getStats();
  }

  createSubscriber(subscriber: Subscriber) {
    return this._subscriberApiService.post(subscriber);
  }

  getEmailById(id: string) {
    return this._subscriberApiService.getById(id);
  }

  deleteSubscriberById(id: string) {
    return this._subscriberApiService.deleteById(id);
  }

  deleteSubscriberByEmail(email: string) {
    return this._subscriberApiService.deletebyEmail(email);
  }

}
