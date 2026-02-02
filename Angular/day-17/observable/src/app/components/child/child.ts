import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  standalone: true,
  templateUrl: './child.html',
})
export class ChildComponent {
  // Parent → Child
  @Input() childName!: string;

  // Child → Parent
  @Output() messageFromChild = new EventEmitter<string>();

  sendToParent() {
    this.messageFromChild.emit('Hello Parent! ');
  }
}
