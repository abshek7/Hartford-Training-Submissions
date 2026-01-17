let counter: number;
// counter = 'Hello';
// // Type 'string' is not assignable to type 'number'.
counter = 1;

let Name: string = 'John';
let age: number = 25;
let active: boolean = true;

console.log(Name);
console.log(age);
console.log(active)
console.log(active)



 //arrays
let names: string[] = ['John', 'Jane', 'Peter', 'David', 'Mary'];
console.log(names)


//obj
const str: string = "GeeksforGeeks";
const num: number = 6;
const arr: (number | string)[] = 
    ["GFG", "TypeScript", 500, 20];

//checking for types
console.log(typeof str);
console.log(typeof num);
console.log(arr);
console.log(typeof arr);


//obj
const person: { name: string; age: number } = {
    name: "Alice",
    age: 30
};
console.log(person);


//in ts we get any ,but in js we get undefined
let x;
console.log(typeof x)

//enums
enum Direction {
    Up,
    Down,
    Left,
    Right
}
//No automatic step size

//If you want a different “step”, you must explicitly assign each value:
let move: Direction = Direction.Up;
console.log(move);

//here in ts fish is not assignable to pet
//but in js we get fish logged out in console
type Animal = "Dog" | "Cat" | "Bird";

let pet: Animal;

pet = "Dog";    
pet = "Cat";    
 
pet = "Fish";   
console.log( pet);


// A new type is created
type type_alias = number | string | boolean;

// Variable is declared of the new type created
let variable: type_alias;
variable = 1; 
console.log(variable);
variable = "geeksforgeeks";
console.log(variable);
variable = true;
console.log(variable);