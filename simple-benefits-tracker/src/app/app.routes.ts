import { Routes } from '@angular/router';

import { Main } from './pages/main/main';
import { ClientsPage } from './pages/clients/clients.page';
import { BenefitsPage } from './pages/benefits/benefits.page';
import { AppointmentsPage } from './pages/appointments/appointments.page';

export const routes: Routes = [
  { path: '', component: Main },
  { path: 'clients', component: ClientsPage },
  { path: 'benefits', component: BenefitsPage },
  { path: 'appointments', component: AppointmentsPage },
];
