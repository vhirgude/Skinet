import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './models/product';
import { Pagination } from './models/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Client';
  products:Product[]=[];
  constructor(private Http:HttpClient){}

  ngOnInit(): void {
    this.Http.get<Pagination<Product[]>>('https://localhost:5001/api/products').subscribe({
      next: response=> this.products=response.data,
      error: error=> console.log(error),
      complete:()=>{
        console.log('error accured');
        console.log('exrea code');
      }
    });
  }

}
