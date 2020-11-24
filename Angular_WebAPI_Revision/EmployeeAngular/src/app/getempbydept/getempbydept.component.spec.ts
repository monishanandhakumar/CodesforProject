import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetempbydeptComponent } from './getempbydept.component';

describe('GetempbydeptComponent', () => {
  let component: GetempbydeptComponent;
  let fixture: ComponentFixture<GetempbydeptComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetempbydeptComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetempbydeptComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
