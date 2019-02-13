import { Component, OnInit, Output } from '@angular/core';
import { HomeService } from '../../shared/services/home/home.service';
import { HomeViewModel } from '../../shared/models/homeViewModel';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  @Output() babysitterUrl: string;

  constructor(private _home: HomeService) { }

  ngOnInit() {
    this._home.getViewModel().subscribe(
      homeViewModel => {
        const resolvedHomeViewModel = new HomeViewModel(homeViewModel.links);

        this.babysitterUrl = resolvedHomeViewModel.babysitterShiftLink;
      },
      error => {
        console.error(error);
      },
      () => {
        console.log('ViewModelService completed');
      }
    );
  }
}
