import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterTeacher } from './register-teacher';

describe('RegisterTeacher', () => {
  let component: RegisterTeacher;
  let fixture: ComponentFixture<RegisterTeacher>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegisterTeacher],
    }).compileComponents();

    fixture = TestBed.createComponent(RegisterTeacher);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
