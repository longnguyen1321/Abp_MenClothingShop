import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportActionComponent } from './import-action.component';

describe('ImportActionComponent', () => {
  let component: ImportActionComponent;
  let fixture: ComponentFixture<ImportActionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportActionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportActionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
