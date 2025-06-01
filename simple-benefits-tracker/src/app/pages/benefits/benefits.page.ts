import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BenefitsService } from '../../services/benefit.service';
import { Benefit } from '../../models/benefit.model';

@Component({
  selector: 'app-benefits-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './benefits.page.html',
  styleUrls: ['./benefits.page.css'],
})

export class BenefitsPage implements OnInit {
    benefits: Benefit[] = [];
    error: string | null = null;
  constructor(private benefitsService: BenefitsService) {}
  ngOnInit(): void {
    this.benefitsService.getAll().subscribe({
      next: (data) => {
        this.benefits = data;
      },
      error: (err) => {
        this.error = 'Failed to load benefits.';
        console.error(err);
      },
    });
  }
}