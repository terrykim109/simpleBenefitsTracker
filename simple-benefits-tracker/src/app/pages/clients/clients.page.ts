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
  showClientCheckboxes = false;
  selectedClients: number[] = [];

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

  toggleClientCheckboxes(): void {
  this.showClientCheckboxes = !this.showClientCheckboxes;
  if (!this.showClientCheckboxes) {
    this.selectedClients = [];
  }
}

toggleClientSelection(id: number, event: any): void {
  
  if (event.target.checked) {
    this.selectedClients.push(id);
  } else {
    this.selectedClients = this.selectedClients.filter(cid => cid !== id);
  }
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

deleteSelectedClients(): void {
  
  const toDelete = [...this.selectedClients];
  toDelete.forEach(id => {
    this.clientService.delete(id).subscribe({
      next: () => {
        this.clients = this.clients.filter(c => c.Client_ID !== id);
        this.selectedClients = this.selectedClients.filter(cid => cid !== id);
      },
      error: (err) => {
        this.error = 'Failed to delete one or more clients.';
        console.error(err);
      }
    });
  });

  this.showClientCheckboxes = false;
}

}