import { Component, OnInit, Input } from '@angular/core';
import { BrandDetailService } from './../../shared/brand-detail.service';
import { BrandDetail } from 'src/app/shared/brand-detail.model';

@Component({
  selector: 'app-brand-detail-list',
  templateUrl: './brand-detail-list.component.html',
  styles: [
  ]
})
export class BrandDetailListComponent implements OnInit {
  p: number = 1;
  brandString: string = '';
  showModalBox: boolean = false;
  data: BrandDetail = new BrandDetail();

  constructor(public brandService: BrandDetailService) { }

  ngOnInit(): void {
    this.brandService.refreshList();
  }

  openModal(id) {
    this.brandService.getBrandDetail(id).subscribe(
      res =>{
        this.data = <BrandDetail>res;
      } 
    );
    if(0){
      this.showModalBox = false;
    } else {
       this.showModalBox = true;
    }
  }

  searchBrand(){
    this.brandService.searchBrandsByName(this.brandString);
  }

  sortByName(){
    this.brandService.getBrandsByName();
  }

  populateForm(selectedBrand) {
    this.brandService.brandFormData = Object.assign({}, selectedBrand);
  }

  onDelete(BrandId) {
    if (confirm('Are you sure to delete this brand? All cars with that brand will get deleted too.')) {
      this.brandService.deleteBrandDetail(BrandId)
        .subscribe(res => {
          this.brandService.refreshList();
        },
        err => { console.log(err); })
    }
  }

}
