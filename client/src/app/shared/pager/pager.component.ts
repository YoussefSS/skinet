import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss'],
})
export class PagerComponent {
  @Input() totalCount?: number;
  @Input() pageSize?: number;
  @Input() pageNumber?: number;
  @Output() pageChanged = new EventEmitter<number>(); // outputting a number

  onPagerChanged(event: any) {
    this.pageChanged.emit(event.page); // emit the event out of this component
  }
}
