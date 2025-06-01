import { Component, OnInit  } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-appointments-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './appointments.page.html',
  styleUrls: ['./appointments.page.css'],
})
export class AppointmentsPage implements OnInit {
  // appointments: Appointment[] = [];
  error = '';

  constructor(
  
  ) {}

  ngOnInit(): void {
  
  }
}
