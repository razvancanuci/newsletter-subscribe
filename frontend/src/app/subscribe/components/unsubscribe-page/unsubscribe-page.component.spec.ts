import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnsubscribePageComponent } from './unsubscribe-page.component';

describe('UnsubscribePageComponent', () => {
  let component: UnsubscribePageComponent;
  let fixture: ComponentFixture<UnsubscribePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UnsubscribePageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UnsubscribePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
