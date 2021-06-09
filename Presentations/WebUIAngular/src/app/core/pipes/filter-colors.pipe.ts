import { Pipe, PipeTransform } from '@angular/core';
import { Color } from '../components/admin/color/models/color';

@Pipe({
  name: 'filterColors'
})
export class FilterColorsPipe implements PipeTransform {

  transform(value: Color[], filterText: string): Color[] {
    filterText ? filterText.toLowerCase() : "";
    return filterText
    ? value.filter((c:Color)=>c.name.toLocaleLowerCase().indexOf(filterText)!=-1)
    : value
  }

}
