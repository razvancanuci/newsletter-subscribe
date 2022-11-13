import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscriber } from '../../../models/models';

@Component({
  selector: 'app-subscriber-form',
  templateUrl: './subscriber-form.component.html',
  styleUrls: ['./subscriber-form.component.css']
})
export class SubscriberFormComponent implements OnInit {


  subscriberForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('')
  });

  @Output()
  formEmitter = new EventEmitter<Subscriber>()
  constructor() { }

  ngOnInit(): void {
  }

  onSubscribe() {
    if (this.subscriberForm.valid) {
      const subscriber = {
        name: <string>this.subscriberForm.controls.name.value,
        email: <string>this.subscriberForm.controls.email.value,
        phoneNumber: this.subscriberForm.controls.phoneNumber.value
      }
      this.formEmitter.emit(subscriber);
    }

  }

}
