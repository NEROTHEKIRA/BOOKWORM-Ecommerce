import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyshelfComponent } from './myshelf.component';

describe('MyshelfComponent', () => {
  let component: MyshelfComponent;
  let fixture: ComponentFixture<MyshelfComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyshelfComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyshelfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
