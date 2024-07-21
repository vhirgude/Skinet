import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/Pagination';
import { Product } from '../shared/models/product';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
baseURL='https://localhost:5001/api/';
  constructor(private Http:HttpClient ) { }

  getProducts(shopParams:ShopParams){
    debugger;
    let params=new HttpParams();
    if(shopParams.brandId) params=params.append('brandid',shopParams.brandId);
    if(shopParams.typeId) params=params.append('typeid',shopParams.typeId);
    if(shopParams.sort) params=params.append('sort',shopParams.sort);
    if(shopParams.pageSize) params=params.append('pageSize',shopParams.pageSize);
    if(shopParams.pageNumber) params=params.append('pageIndex',shopParams.pageNumber);
    if(shopParams.search) params=params.append('search',shopParams.search);

    return this.Http.get<Pagination<Product[]>>(this.baseURL+'products',{params});
  }
  getBrands(){
    return this.Http.get<Brand[]>(this.baseURL+'products/Brands');
  }
  getTypes(){
    return this.Http.get<Type[]>(this.baseURL+'products/Types');
  }
}
