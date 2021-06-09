import { Pipe, PipeTransform } from '@angular/core';
import { Brand } from '../components/admin/brand/models/brand';

@Pipe({
  name: 'filterBrands'
})
export class FilterBrandsPipe implements PipeTransform {

  transform(value: Brand[], filterText:string): Brand[] {
    filterText ? filterText.toLowerCase() : "";
    return filterText
    ? value.filter((b:Brand)=>b.name.toLocaleLowerCase().indexOf(filterText)!=-1)
    : value
  }

}
