import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-benefits-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './benefits.page.html',
  styleUrls: ['./benefits.page.css'],
})

export class BenefitsPage implements OnInit {
  
  error = '';
  constructor(
    ) {}
  ngOnInit(): void {
      }
}