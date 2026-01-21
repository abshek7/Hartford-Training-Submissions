import { Component ,OnInit} from '@angular/core';
import { Employee } from '../models/employee';
import { CommonModule, DatePipe } from '@angular/common';

@Component({
  selector: 'app-list-employees',
  imports: [DatePipe,CommonModule],
  templateUrl: './list-employees.html',
  styleUrl: './list-employees.css',
})
export class ListEmployees implements OnInit{
  employees:Employee[]=[
    {id: 1,
 name: 'Chimtu',
 gender: 'Male',
 contactPreference: 'Email',
 email: 'mark@pragimtech.com',
 dateOfBirth: new Date('10/25/1988'),
 department: 'IT',
 isActive: true,
 photoPath: './image.png'
 },
 {
 id: 2,
 name: 'Chimki',
 gender: 'Female',
 contactPreference: 'Phone',
 phoneNumber: 2345978640,
 dateOfBirth: new Date('11/20/1979'),
 department: 'HR',
 isActive: true,
 photoPath: './image.png'
 },

 {
 id: 3,
 name: 'Chimtu',
 gender: 'Male',
 contactPreference: 'Email',
 email: 'mark@pragimtech.com',
 dateOfBirth: new Date('10/25/1988'),
 department: 'IT',
 isActive: true,
 photoPath: './image.png'

    },
  ];

 ngOnInit() {
  console.log("i am called second because this is init hook")
 } 
// here constructor is called first even though it is written after hook

   constructor() {console.log("iam called first because i am constructor") }

}
