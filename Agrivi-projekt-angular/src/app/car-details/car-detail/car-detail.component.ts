import { CarDetailService } from './../../shared/car-detail.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BrandDetailService } from 'src/app/shared/brand-detail.service';
import { BrandDetail } from 'src/app/shared/brand-detail.model';
@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styles: [
  ]
})
export class CarDetailComponent implements OnInit {

  constructor(public carService: CarDetailService, public brandService: BrandDetailService) {}

  ngOnInit(): void {
    this.resetForm();
    this.brandService.refreshList();
  }

  resetForm(form?: NgForm){
    if(form != null)
      form.form.reset();
    this.carService.carFormData = {
      CarId: 0,
      CarName: '',
      CarDate: '',
      CarDescription: '',
      BrandId: 0
    }
  }
  onSubmit(form: NgForm) {
    if (this.carService.carFormData.CarId == 0)
      this.insertCar(form);
    else
      this.updateCar(form);
  }
  insertCar(form: NgForm) {
    this.carService.postCarDetail().subscribe(
      res => {
        this.resetForm(form);
        this.carService.refreshList();
      },
      err => { console.log(err); }
    )
  }
  
  updateCar(form: NgForm) {
    this.carService.putCarDetail().subscribe(
      res => {
        this.resetForm(form);
        //this.toastr.info('Submitted successfully', 'Car Detail REgister');
        this.carService.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }
}
