import { Injectable, signal } from '@angular/core';
import { Todo } from '../../models/todo/todo';

@Injectable({ providedIn: 'root' })
export class TodoService {
  private todos = signal<Todo[]>([]);
  private idCounter = 1;

  getTodos() {
    return this.todos;
  }

  addTodo(title: string) {
    this.todos.update(todos => [
      ...todos,
      { id: this.idCounter++, title, completed: false }
    ]);
  }

  updateTodo(updated: Todo) {
    this.todos.update(todos =>
      todos.map(t => (t.id === updated.id ? updated : t))
    );
  }

  deleteTodo(id: number) {
    this.todos.update(todos => todos.filter(t => t.id !== id));
  }

  toggleTodo(id: number) {
    this.todos.update(todos =>
      todos.map(t =>
        t.id === id ? { ...t, completed: !t.completed } : t
      )
    );
  }
}
