import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './paging-header/paging-header.component';

@NgModule({
  declarations: [PagingHeaderComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot(), // forRoot so it's loaded as a singleton and the same module is used throughout the app
  ],
  exports: [PaginationModule, PagingHeaderComponent],
})
export class SharedModule {}
