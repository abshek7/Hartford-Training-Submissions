"use strict";
let counter;
// counter = 'Hello';
// // Type 'string' is not assignable to type 'number'.
counter = 1;
let Name = 'John';
let age = 25;
let active = true;
console.log(Name);
console.log(age);
console.log(active);
console.log(active);
//arrays
let names = ['John', 'Jane', 'Peter', 'David', 'Mary'];
console.log(names);
//obj
const str = "GeeksforGeeks";
const num = 6;
const arr = ["GFG", "TypeScript", 500, 20];
//checking for types
console.log(typeof str);
console.log(typeof num);
console.log(arr);
console.log(typeof arr);
//obj
const person = {
    name: "Alice",
    age: 30
};
console.log(person);
//in ts we get any ,but in js we get undefined
let x;
console.log(typeof x);
//enums
var Direction;
(function (Direction) {
    Direction[Direction["Up"] = 0] = "Up";
    Direction[Direction["Down"] = 1] = "Down";
    Direction[Direction["Left"] = 2] = "Left";
    Direction[Direction["Right"] = 3] = "Right";
})(Direction || (Direction = {}));
//No automatic step size
//If you want a different “step”, you must explicitly assign each value:
let move = Direction.Up;
console.log(move);
let pet;
pet = "Dog";
pet = "Cat";
pet = "Fish";
console.log(pet);
// Variable is declared of the new type created
let variable;
variable = 1;
console.log(variable);
variable = "geeksforgeeks";
console.log(variable);
variable = true;
console.log(variable);
