import { Component, OnInit  } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientService } from '../../services/client.service';
import { Client } from '../../../app/models/client.model';
import { FormsModule } from '@angular/forms'; 

@Component({
  selector: 'app-clients-page',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './clients.page.html',
  styleUrls: ['./clients.page.css'],
})

export class ClientsPage implements OnInit {
  clients: Client[] = [];
    newClient: Partial<Client> = {
    First_Name: '',
    Last_Name: '',
    Current_Program: '',
    Current_Status: '',
    Program_StartDate: '',
    Program_ExpiryDate: '',
    Program_LastRenewal: '',
    Email_Address: '',
    Next_AppointmentDate: null,
  };

showForm = false;
  error = '';
  constructor(private clientService: ClientService) {}

 ngOnInit(): void {
    this.loadClients();
  }
 loadClients(): void {
    this.clientService.getAll().subscribe({
      next: (data) => {
        this.clients = data;
      },
      error: (err) => {
        this.error = 'Failed to load clients.';
        console.error(err);
      },
    });
  }

  addClient(): void {
    this.clientService.create(this.newClient).subscribe({
      next: (added) => {
        this.clients.push(added);
        this.showForm = false;
        this.resetNewClient();
      },
      error: (err) => {
        this.error = 'Failed to add client.';
        console.error(err);
      },
    });
  }

  resetNewClient() {
    this.newClient = {
      First_Name: '',
      Last_Name: '',
      Current_Program: '',
      Current_Status: '',
      Program_StartDate: '',
      Program_ExpiryDate: '',
      Program_LastRenewal: '',
      Email_Address: '',
      Next_AppointmentDate: null,
    };
  }
}

