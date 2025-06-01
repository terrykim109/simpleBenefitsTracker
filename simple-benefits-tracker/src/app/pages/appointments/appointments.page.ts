import { Component, OnInit  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentsService } from '../../services/appointments.service';
import { Appointment } from '../../models/appointments.model';


@Component({
  selector: 'app-appointments-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './appointments.page.html',
  styleUrls: ['./appointments.page.css'],
})

export class AppointmentsPage implements OnInit {
  appointments: Appointment[] = []; 
  error = '';
  showForm = false;

  newAppointment: Appointment = {
    Appointment_ID: 0,
    Client_ID: 0,
    Appointment_DateTime: '',
    Location: '',
    Client_Notes: ''
  };

  constructor(private appointmentsService: AppointmentsService) {} 

  ngOnInit(): void {
    this.loadAppointments();
  }

  loadAppointments(): void {
    this.appointmentsService.getAll().subscribe({
      next: (data) => {
        this.appointments = data;
      },
      error: (err) => {
        this.error = 'Failed to load appointments.';
        console.error(err);
      },
    });
  }

  addAppointment(): void {
    this.appointmentsService.add(this.newAppointment).subscribe({
      next: (added) => {
        this.appointments.push(added);
        this.showForm = false;
        this.newAppointment = {
          Appointment_ID: 0,
          Client_ID: 0,
          Appointment_DateTime: '',
          Location: '',
          Client_Notes: ''
        };
      },
      error: (err) => {
        this.error = 'Failed to add appointment.';
        console.error(err);
      },
    });
  }
}

//   ngOnInit(): void {
//     this.appointmentsService.getAll().subscribe({
//       next: (data) => {
//         this.appointments = data;
//       },
//       error: (err) => {
//         this.error = 'Failed to load appointments.';
//         console.error(err);
//       },
//     });
//   }
// }