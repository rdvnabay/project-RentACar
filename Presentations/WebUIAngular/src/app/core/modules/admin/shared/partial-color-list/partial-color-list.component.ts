import { Component, OnInit } from '@angular/core';
import { Color } from 'src/app/core/components/admin/color/models/color';
import { ColorService } from 'src/app/core/components/admin/color/services/color.service';

@Component({
  selector: 'app-partial-color-list',
  templateUrl: './partial-color-list.component.html',
  styleUrls: []
})
export class PartialColorListComponent implements OnInit {

  colors:Color[]=[];
  constructor(private colorService:ColorService) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
return this.colorService.getAll().subscribe(response=>{
  this.colors=response.data;
})
  }

}
