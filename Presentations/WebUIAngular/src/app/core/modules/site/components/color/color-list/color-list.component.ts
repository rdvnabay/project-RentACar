import { Component, OnInit } from '@angular/core';
import { Color } from 'src/app/core/models/color';
import { ColorService } from 'src/app/core/services/color.service';

@Component({
  selector: 'app-color-list',
  templateUrl: './color-list.component.html',
  styleUrls: []
})
export class ColorListComponent implements OnInit {

  colors:Color[]=[];
  constructor(private colorService:ColorService) { }

  ngOnInit(): void {
  this.getAll();
  }

  getAll(){
    this.colorService.getAll().subscribe(response=>{
    this.colors=response.data;
    })
  }

}
