import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Color } from 'src/app/core/models/color';
import { ColorService } from 'src/app/core/services/color.service';

@Component({
  selector: 'app-color-list',
  templateUrl: './color-list.component.html',
  styleUrls: []
})
export class ColorListComponent implements OnInit {

  colors: Color[] = [];
  constructor(
    private colorService: ColorService,
    private router: Router,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.colorService.getAll().subscribe(response => {
      this.colors = response.data;
    });
  }

  delete(color: Color) {
    this.colorService.delete(color).subscribe(response => {
      this.toastrService.warning('Renk silindi', 'Başarılı');
      this.router.navigateByUrl('');
    });
  }
}
