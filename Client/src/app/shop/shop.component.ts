import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../shared/models/product';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search') searchterm?:ElementRef;
  products:Product[]=[];
  brands:Brand[]=[];
  types:Type[]=[];
  
  sortOptions=[
    {name:'A-Z',value:'name'},
    {name:'Price high to low',value:'priceAsc'},
    {name:'Price low to high',value:'priceDesc'}
  ]
  shopParams=new ShopParams();
  totalCount=0;

  constructor(private shopService:ShopService) { }

  ngOnInit(): void {   
    this.getProducts();
    this.getBrands();
    this.getTypes();    
  }
  getProducts(){
    this.shopService.getProducts(this.shopParams).subscribe({
      next: response=> {
        this.products=response.data;
        this.shopParams.pageNumber=response.pageIndex;
        this.shopParams.pageSize=response.pageSize;
        this.totalCount=response.count;

      },
      error: error=> console.log(error)
    });
  }
  getBrands(){
    //Brands
    this.shopService.getBrands().subscribe({
      next: (response)=> {
        this.brands=[{id:0,name:'All'},...response];
        console.log(response);

      },
      error: error=> console.log(error)
    });
  }

  getTypes(){
    //Types
    this.shopService.getTypes().subscribe({
      next: response=> this.types=[{id:0,name:'All'},...response],
      error: error=> console.log(error)
    });
  }

  onBrandIdSelected(brandid:number){
    this.shopParams.brandId=brandid;
    this.shopParams.pageNumber=1;
    this.getProducts();

  }
  onTypeIdSelected(typeid:number){
    this.shopParams.typeId=typeid;
    this.shopParams.pageNumber=1;
    this.getProducts();
  }

  onSortSelected(event:any){
    this.shopParams.sort=event.target.value;
    this.getProducts();
  }
  onPageChange(event:any)
  {
    if(this.shopParams.pageNumber!==event){
      this.shopParams.pageNumber=event;
      this.getProducts();
    }
  }
  onSearch(){
    this.shopParams.search=this.searchterm?.nativeElement.value;
    this.shopParams.pageNumber=1;
   this.getProducts();

  }

  onReset()
  {
    if(this.searchterm) this.searchterm?.nativeElement.value=='';
    this.shopParams=new ShopParams();
    this.getProducts();
  }

}
