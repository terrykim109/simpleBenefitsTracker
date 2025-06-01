import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

//gov library
import { ComponentLibraryModule } from '@ongov/ontario-design-system-component-library-angular/dist/component-library';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ComponentLibraryModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'simple-benefits-tracker';
}
