import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Main } from './main/main';

@NgModule({
  declarations: [
    Main,
  ],
  imports: [
    CommonModule
  ],
  exports: [
    Main,
   ]
})
export class PagesModule {}
