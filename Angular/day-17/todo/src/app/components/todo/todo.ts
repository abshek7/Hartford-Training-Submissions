import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TodoService } from  '../../services/todo/todo';

@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './todo.html',
})
export class TodoComponent {
  private todoService = inject(TodoService);

  todos = this.todoService.getTodos();
  newTitle = '';
  editingId: number | null = null;
  editingTitle = '';

  addTodo() {
    if (!this.newTitle.trim()) return;
    this.todoService.addTodo(this.newTitle);
    this.newTitle = '';
  }

  startEdit(id: number, title: string) {
    this.editingId = id;
    this.editingTitle = title;
  }

  saveEdit(id: number) {
    const todo = this.todos().find(t => t.id === id);
    if (!todo) return;

    this.todoService.updateTodo({
      ...todo,
      title: this.editingTitle,
    });

    this.editingId = null;
  }

  deleteTodo(id: number) {
    this.todoService.deleteTodo(id);
  }

  toggleTodo(id: number) {
    this.todoService.toggleTodo(id);
  }
}
