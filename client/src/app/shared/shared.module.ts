import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagerComponent } from './pager/pager.component';

@NgModule({
  declarations: [PagingHeaderComponent, PagerComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot(), // forRoot so it's loaded as a singleton and the same module is used throughout the app
  ],
  exports: [PaginationModule, PagingHeaderComponent, PagerComponent],
})
export class SharedModule {}
