import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { NavbarComponent } from './navbar.component';

describe('NavbarComponent', () => {
  let component: NavbarComponent;
  let fixture: ComponentFixture<NavbarComponent>;

  beforeEach(async () => {
    // Setup the testing module
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule], 
      declarations: [NavbarComponent],
      schemas: [CUSTOM_ELEMENTS_SCHEMA] // For custom elements
      }).compileComponents();
      });

      beforeEach(() => {
    fixture = TestBed.createComponent(NavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
      });

  // Test for component creation
  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
