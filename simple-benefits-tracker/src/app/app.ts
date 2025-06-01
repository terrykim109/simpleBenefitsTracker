import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

//gov library
import { OntarioDesignSystemModule } from '@ongov/ontario-design-system-component-library-angular';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, OntarioDesignSystemModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'simple-benefits-tracker';
}
