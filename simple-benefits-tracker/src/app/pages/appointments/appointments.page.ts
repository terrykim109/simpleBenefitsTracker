import { Component, OnInit  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentsService } from '../../services/appointments.service';
import { Appointment } from '../../models/appointments.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-appointments-page',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './appointments.page.html',
  styleUrls: ['./appointments.page.css'],
})

export class AppointmentsPage implements OnInit {
  appointments: Appointment[] = []; 
  error = '';
  showForm = false;

  showCheckboxes = false;
  selectedAppointments: number[] = [];

  newAppointment: Appointment = {
    Appointment_ID: 0,
    Client_ID: 0,
    Appointment_DateTime: '',
    Location: '',
    Client_Notes: ''
  };

  constructor(private appointmentsService: AppointmentsService) {} 

  ngOnInit(): void {
    this.loadAppointments(); //loading appointments on component initialization
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
    this.appointmentsService.create(this.newAppointment).subscribe({
      next: (added) => {
        this.appointments.push(added);
        this.showForm = false;
        this.resetNewAppointment();
      },
      error: (err) => {
        this.error = 'Failed to add appointment.';
        console.error(err);
      },
    });
  }

  resetNewAppointment(): void {
    this.newAppointment = {
      Appointment_ID: 0, 
      Client_ID: 0,
      Appointment_DateTime: '',
      Location: '',
      Client_Notes: '',
    };
  }

  toggleCheckboxes(): void {
  this.showCheckboxes = !this.showCheckboxes;
  if (!this.showCheckboxes) {
    this.selectedAppointments = [];
  }
}

toggleSelection(appointmentId: number, event: Event) {
  const checked = (event.target as HTMLInputElement).checked;
  if (checked) {
    if (!this.selectedAppointments.includes(appointmentId)) {
      this.selectedAppointments.push(appointmentId);
    }
  } else {
    this.selectedAppointments = this.selectedAppointments.filter(id => id !== appointmentId);
  }
}

deleteSelectedAppointments(): void {
  const toDelete = [...this.selectedAppointments]; // Creating a shallow copy
  toDelete.forEach(id => {
    this.appointmentsService.delete(id).subscribe({
      next: () => { 
        this.appointments = this.appointments.filter(a => a.Appointment_ID !== id); // Removing from local list
        this.selectedAppointments = this.selectedAppointments.filter(aid => aid !== id); // Also remove from selected list
      },
      error: (err) => {
        this.error = 'Failed to delete one or more appointments.';
        console.error(err);
      }
    });
  });

  this.showCheckboxes = false; // Hide checkboxes after deletion
}
}