import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportCartComponent } from './import-cart.component';

describe('ImportCartComponent', () => {
  let component: ImportCartComponent;
  let fixture: ComponentFixture<ImportCartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportCartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportCartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
