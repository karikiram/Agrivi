import { Injectable } from '@angular/core';
import { CarDetail } from './car-detail.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarDetailService {
  carFormData: CarDetail;
  readonly rootUrl = 'http://localhost:50000/api';
  carList : CarDetail[];

  constructor(private http: HttpClient) { }

  postCarDetail() {
    return this.http.post(this.rootUrl + '/Cars', this.carFormData);
  }

  putCarDetail() {
    return this.http.put(this.rootUrl + '/Cars/' + this.carFormData.CarId, this.carFormData);
  }

  deleteCarDetail(id) {
    return this.http.delete(this.rootUrl + '/Cars/' + id);
  }

  refreshList(){
    this.carList = null;
    this.http.get(this.rootUrl + '/Cars')
    .toPromise()
    .then(res => this.carList = res as CarDetail[]);
  }


  getCarsByName(){
    this.http.get(this.rootUrl + '/Filter/GetCarsByName')
    .toPromise()
    .then(res => this.carList = res as CarDetail[]);
  }

  getCarsByDate(){
    this.http.get(this.rootUrl + '/Filter/GetCarsByDate')
    .toPromise()
    .then(res => this.carList = res as CarDetail[]);
  }

  getCarsByBrand(){
    this.http.get(this.rootUrl + '/Filter/GetCarsByBrand')
    .toPromise()
    .then(res => this.carList = res as CarDetail[]);
  }

  searchCarsByName(carName){
    this.http.get(this.rootUrl + '/Filter/SearchCarsByName/' + carName)
    .toPromise()
    .then(res => this.carList = res as CarDetail[]);
  }
}
