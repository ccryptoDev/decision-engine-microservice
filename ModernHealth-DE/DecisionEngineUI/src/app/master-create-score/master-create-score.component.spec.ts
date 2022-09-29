import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MasterCreateScoreComponent } from './master-create-score.component';

describe('MasterCreateScoreComponent', () => {
  let component: MasterCreateScoreComponent;
  let fixture: ComponentFixture<MasterCreateScoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MasterCreateScoreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MasterCreateScoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
