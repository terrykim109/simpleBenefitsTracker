import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BenefitsService } from '../../services/benefit.service';
import { Benefit } from '../../models/benefit.model';
import { FormsModule } from '@angular/forms'; 

@Component({
  selector: 'app-benefits-page',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './benefits.page.html',
  styleUrls: ['./benefits.page.css'],
})

export class BenefitsPage implements OnInit {
  benefits: Benefit[] = [];
  error: string | null = null;
  
  showUpdateMode: boolean = false;
  selectedBenefitId: number | null = null;
  editingBenefit: Benefit | null = null;

  constructor(private benefitsService: BenefitsService) {}

  ngOnInit(): void {
    this.loadBenefits(); // loading benefits on component intialization
  }

   loadBenefits(): void {
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

  toggleUpdateMode(): void {
    this.showUpdateMode = !this.showUpdateMode;
    this.cancelEdit();
  }

    startEdit(benefit: Benefit): void {
    this.selectedBenefitId = benefit.Benefits_ID;
    this.editingBenefit = { ...benefit }; 
  }


 saveBenefit(): void {
  if (!this.editingBenefit) return;

  this.benefitsService.update(this.editingBenefit.Benefits_ID, this.editingBenefit).subscribe({
    next: (updatedBenefit) => {
      const index = this.benefits.findIndex(b => b.Benefits_ID === updatedBenefit.Benefits_ID);
      if (index > -1) {
        this.benefits[index] = updatedBenefit; // Updating the local array 
      }
      this.cancelEdit();
    },
    error: (err) => {
      this.error = 'Failed to update benefit.';
      console.error(err);
    }
  });
}

  cancelEdit(): void {
    this.editingBenefit = null;
    this.selectedBenefitId = null;
  }

  formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = ('0' + (date.getMonth() + 1)).slice(-2);
    const day = ('0' + date.getDate()).slice(-2);
    return `${year}-${month}-${day}`;
  }

  confirmUpdate(): void {

  if (!this.selectedBenefitId) return;

  const selected = this.benefits.find(b => b.Benefits_ID === this.selectedBenefitId); // Finding the selected benefit by ID
  
  if (selected) {
    this.editingBenefit = { ...selected };
  }
  this.selectedBenefitId = null;
 }
}
