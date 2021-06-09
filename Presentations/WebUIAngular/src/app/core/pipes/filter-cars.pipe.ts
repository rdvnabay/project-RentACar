import { Pipe, PipeTransform } from '@angular/core';
import { Car } from '../components/admin/car/models/car';

@Pipe({
  name: 'filterCars'
})
export class FilterCarsPipe implements PipeTransform {

  transform(value: Car[], filterText: string): Car[] {
    filterText ? filterText.toLowerCase() : "";
    return filterText
    ? value.filter((c:Car)=>c.name.toLocaleLowerCase().indexOf(filterText)!=-1)
    : value
  }

}
