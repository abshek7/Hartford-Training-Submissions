import { Component, signal } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-public-dashboard',
  imports: [RouterLink],
  templateUrl: './public-dashboard.html'
})
export class PublicDashboard {

  loading = signal(false);

  blogs = signal([
    {
      id: 1,
      title: 'Understanding Microservices Architecture',
      content: 'Learn how modern systems scale using microservices, APIs, and distributed communication patterns.',
      comments: [1, 2, 3]
    },
    {
      id: 2,
      title: 'System Design Basics for Beginners',
      content: 'A beginner-friendly guide to load balancing, caching, databases, and scaling applications.',
      comments: [1]
    },
    {
      id: 3,
      title: 'Event-Driven Architecture Explained',
      content: 'Explore Kafka, message queues, and asynchronous communication used in large-scale systems.',
      comments: [1, 2]
    },
    {
      id: 4,
      title: 'How Netflix Handles Millions of Users',
      content: 'A deep dive into streaming architecture, CDNs, and distributed data systems.',
      comments: [1, 2, 3, 4]
    },
    {
      id: 5,
      title: 'Database Scaling Strategies',
      content: 'Vertical vs horizontal scaling, sharding, replication, and performance optimization.',
      comments: [1]
    },
    {
      id: 6,
      title: 'Building Real-Time Applications',
      content: 'Learn WebSockets, polling, and streaming architectures for chat and collaboration apps.',
      comments: [1, 2]
    }
  ]);
}