import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgbTime } from '@ng-bootstrap/ng-bootstrap/timepicker/ngb-time';
import { NgbTimeStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-shift-time-picker',
  templateUrl: './shift-time-picker.component.html',
  styleUrls: ['./shift-time-picker.component.css']
})
export class ShiftTimePickerComponent implements OnInit {

  @Input() time: NgbTimeStruct = { hour: 17, minute: 0, second: 0 };
  meridian: boolean;
  minuteStep: number;

  @Output() selectedTime: EventEmitter<NgbTimeStruct> = new EventEmitter<NgbTimeStruct>();

  constructor() { }

  ngOnInit() {
    this.meridian = true;
    this.minuteStep = 60;
  }

  timeSelected(event: NgbTimeStruct)  {
    this.selectedTime.emit(this.time);
  }

}
