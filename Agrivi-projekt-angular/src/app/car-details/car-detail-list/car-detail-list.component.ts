import { CarDetailService } from './../../shared/car-detail.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car-detail-list',
  templateUrl: './car-detail-list.component.html',
  styles: [
  ]
})
export class CarDetailListComponent implements OnInit {
  p: number = 1;
  carString : string = '';


  constructor(public carService: CarDetailService) { }

  ngOnInit(): void {
    this.carService.refreshList();
  }

  searchCar(){
    this.carService.searchCarsByName(this.carString);
  }

  sortByName(){
    this.carService.getCarsByName();
  }

  sortByDate(){
    this.carService.getCarsByDate();
  }

  sortByBrand(){
    this.carService.getCarsByBrand();
  }
  populateForm(selectedCar) {
    this.carService.carFormData = Object.assign({}, selectedCar);
  }

  onDelete(CarId) {
    if (confirm('Are you sure to delete this car ?')) {
      this.carService.deleteCarDetail(CarId)
        .subscribe(res => {
          this.carService.refreshList();
        },
        err => { console.log(err); })
    }
  }

}
