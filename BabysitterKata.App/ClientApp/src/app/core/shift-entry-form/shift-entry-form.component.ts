import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { BabysitterShiftService } from 'src/app/shared/services/babysitter/babysitter-shift.service';
import { NgForm } from '@angular/forms';
import { Babysitter } from 'src/app/shared/models/babysitter';

@Component({
  selector: 'app-shift-entry-form',
  templateUrl: './shift-entry-form.component.html',
  styleUrls: ['./shift-entry-form.component.css']
})
export class ShiftEntryFormComponent implements OnInit {

  @Input() workShiftPath: string;

  @ViewChild('f') slForm: NgForm;

  selectedFamily: string;

  constructor(private _babysitterShiftService: BabysitterShiftService) { }

  ngOnInit() {
  }

  addShift(form: NgForm) {
    const shiftData = form.value as Babysitter;

    shiftData.familyId = this.selectedFamily;

    this._babysitterShiftService.workShift(this.workShiftPath, shiftData).subscribe(
      result => console.log(result),
      error => console.error(error)
    );
  }

  getSelectedFamily(familyId: string) {
    this.selectedFamily = familyId;
  }
}
