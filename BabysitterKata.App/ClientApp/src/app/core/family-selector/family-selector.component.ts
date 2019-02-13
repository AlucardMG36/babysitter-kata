import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Family } from '../../shared/models/family';

@Component({
  selector: 'app-family-selector',
  templateUrl: './family-selector.component.html',
  styleUrls: ['./family-selector.component.css']
})
export class FamilySelectorComponent implements OnInit {

  @Output() selectedFamily: EventEmitter<string> = new EventEmitter<string>();

  Families: Family[];

  constructor() { }

  ngOnInit() {
    this.loadFamilies();
  }

  loadFamilies() {
    this.Families = [
      { Id: 'A', Name: 'Family A' },
      { Id: 'B', Name: 'Family B' },
      { Id: 'C', Name: 'Family C' }
    ];
  }

  familySelected(event: { target: { value: string; }; }) {
    this.selectedFamily.emit(event.target.value);
  }
}
