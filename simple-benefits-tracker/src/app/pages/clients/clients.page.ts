import { Component, OnInit  } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientService, Client } from '../../services/client.service';

@Component({
  selector: 'app-clients-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './clients.page.html',
  styleUrls: ['./clients.page.css'],
})

export class ClientsPage implements OnInit {
  clients: Client[] = [];
  error = '';

  constructor(private clientService: ClientService) {}

  ngOnInit(): void {

    this.clientService.getAll().subscribe({
      next: (data) => {
        this.clients = data;
      },
      error: (err) => {
        console.error('Failed to load clients:', err);
        this.error = 'Unable to fetch clients at this time.';
      },
    });
  }
}