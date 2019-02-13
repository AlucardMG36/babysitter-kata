import { BabysitterShiftService } from '../../shared/services/babysitter/babysitter-shift.service';
import { BabysitterViewModel } from '../../shared/models/babysitterViewModel';
import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { NgbTimeStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-shift-entry-form',
  templateUrl: './shift-entry-form.component.html',
  styleUrls: ['./shift-entry-form.component.css']
})
export class ShiftEntryFormComponent implements OnInit {

  @Input() workShiftPath: string;

  selectedFamily: string;
  startTime: NgbTimeStruct;
  endTime: NgbTimeStruct;
  resolvedBabysitter = new BabysitterViewModel();

  constructor(private _babysitterShiftService: BabysitterShiftService) { }

  ngOnInit() {
    this.clearForm();

  }

  calculatePayForShift() {
    const url = this.workShiftPath + `?familyId=${this.selectedFamily}&startTime=${this.startTime.hour}&endTime=${this.endTime.hour}`;

    this._babysitterShiftService.getPayforShift(url).subscribe(
      result => {

        this.resolvedBabysitter.data = result.data;
        this.resolvedBabysitter.errors = result.errors;
        this.resolvedBabysitter.links = result.links;

        if ( this.resolvedBabysitter.errors !== undefined && this.resolvedBabysitter.errors.length > 0) {

          let errorMessage = '';

          this.resolvedBabysitter.errors.forEach(er => errorMessage += `${er.message}\n`);

          alert(`Error: ${errorMessage}`);
        }


        alert(`Night earnings For Family${this.resolvedBabysitter.data.currentFamily}: $${this.resolvedBabysitter.data.payForShift}.00`);
      },
      error => {
        return console.error(error);
      },
      () => this.clearForm()
    );
  }

  clearForm() {
    this.selectedFamily = '';
    this.startTime = { hour: 17, minute: 0, second: 0 };
    this.endTime = { hour: 17, minute: 0, second: 0 };
  }

  getSelectedFamily(familyId: string) {
    this.selectedFamily = familyId;
  }

  getStartTime(startTime: NgbTimeStruct) {
    this.startTime = startTime;
  }

  getEndTime(endTime: NgbTimeStruct) {
    this.endTime = endTime;
  }

}
