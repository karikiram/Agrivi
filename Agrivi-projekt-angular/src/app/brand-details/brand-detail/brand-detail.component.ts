import { Component, OnInit } from '@angular/core';
import { BrandDetailService } from 'src/app/shared/brand-detail.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-brand-detail',
  templateUrl: './brand-detail.component.html',
  styles: [
  ]
})
export class BrandDetailComponent implements OnInit {

  constructor(public brandService: BrandDetailService) { }

  ngOnInit(): void {
    this.resetForm();
  }


  resetForm(form?: NgForm){
    if(form != null)
      form.form.reset();
    this.brandService.brandFormData = {
      BrandId: 0,
      BrandName: '',
      Car: []
    }
  }

  onSubmit(form: NgForm) {
    if (this.brandService.brandFormData.BrandId == 0)
      this.insertBrand(form);
    else
      this.updateBrand(form);
  }
  insertBrand(form: NgForm) {
    this.brandService.postBrandDetail().subscribe(
      res => {
        this.resetForm(form);
        this.brandService.refreshList();
      },
      err => { console.log(err); }
    )
  }
  
  updateBrand(form: NgForm) {
    this.brandService.putBrandDetail().subscribe(
      res => {
        this.resetForm(form);
        this.brandService.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }

}
