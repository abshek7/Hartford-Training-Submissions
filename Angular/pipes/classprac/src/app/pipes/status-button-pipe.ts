import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'statusClass',
  standalone: true
})
export class StatusClassPipe implements PipeTransform {

  transform(statusId: number): string {
    switch (statusId) {
      case 1:
        return 'bg-yellow-500 text-white';
      case 2:
        return 'bg-blue-500 text-white';
      case 3:
        return 'bg-green-500 text-white';
      case 4:
        return 'bg-red-500 text-white';
      default:
        return 'bg-gray-400 text-white';
    }
  }
}
