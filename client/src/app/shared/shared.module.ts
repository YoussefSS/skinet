import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    PaginationModule.forRoot(), // forRoot so it's loaded as a singleton and the same module is used throughout the app
  ],
  exports: [PaginationModule],
})
export class SharedModule {}
