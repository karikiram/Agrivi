import { Injectable } from '@angular/core';
import { BrandDetail } from './brand-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BrandDetailService {
  brandFormData: BrandDetail;
  readonly rootUrl = 'http://localhost:50000/api';
  brandList : BrandDetail[];
  brand: BrandDetail;

  constructor(private http: HttpClient) { }

  postBrandDetail() {
    return this.http.post(this.rootUrl + '/Brands', this.brandFormData);
  }

  putBrandDetail() {
    return this.http.put(this.rootUrl + '/Brands/' + this.brandFormData.BrandId, this.brandFormData);
  }

  deleteBrandDetail(id) {
    return this.http.delete(this.rootUrl + '/Brands/' + id);
  }

  refreshList(){
    this.http.get(this.rootUrl + '/Brands')
    .toPromise()
    .then(res => this.brandList = res as BrandDetail[]);
  }

  getBrandDetail(id){
    return this.http.get(this.rootUrl + '/Brands/' + id);
  }

  getBrandsByName(){
    this.http.get(this.rootUrl + '/Filter/GetBrandsByName')
    .toPromise()
    .then(res => this.brandList = res as BrandDetail[]);
  }

  searchBrandsByName(brandName){
    this.http.get(this.rootUrl + '/Filter/SearchBrandsByName/' + brandName)
    .toPromise()
    .then(res => this.brandList = res as BrandDetail[]);
  }
}
