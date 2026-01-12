const customers = [
 { id: 1, name: "Ravi", age: 32, policy: "Health", premium: 4800, active: true },
 { id: 2, name: "Anita", age: 51, policy: "Life", premium: 12000, active: true },
 { id: 3, name: "Kiran", age: 28, policy: "Vehicle", premium: 3500, active: false },
 { id: 4, name: "Meena", age: 45, policy: "Health", premium: 6000, active: true },
 { id: 5, name: "Suresh", age: 60, policy: "Life", premium: 18000, active: false }
]; 

// Bug 1 : Loop runs one extra time (i <= customers.length) causing undefined.

 
for (let i = 0; i < customers.length; i++) {
  console.log(customers[i].name);
}



// Bug 2 : No return statement inside filter callback.

const activeCustomers = customers.filter((c) => {
  return c.active === true;
});


// const activeCustomers = customers.filter((c) => c.active === true);


// Bug 3 : map() does not return anything Mutates original object (breaks immutability)

const updatedPremiums = customers.map((c) => {
  if (c.age >= 50) {
    return { ...c, premium: c.premium * 1.1 };
  }
  return c;
});


// Bug 4 : No return inside reduce callback

const totalPremium = customers.reduce((total, c) => {
  return total + c.premium;
}, 0);


// Bug 5 : Uses normal quotes instead of backticks.

console.log(`Customer ${customers[0].name} has policy ${customers[0].policy}`);


// Bug 6 : Uses count.policy instead of dynamic key.


const policyCount = customers.reduce((count, c) => {
  count[c.policy] = (count[c.policy] || 0) + 1;
  return count;
}, {});



// Bug 7 : Wrong condition chaining

 
const customersWithRisk = customers.map((c) => {
  let riskLevel;

  if (c.age < 35) riskLevel = "Low";
  else if (c.age <= 50) riskLevel = "Medium";
  else riskLevel = "High";

  return { ...c, riskLevel };
});


// Bug 8 : Using for...in instead of for...of

 
let active = 0,
    inactive = 0;

for (const c of customers) {
  if (c.active) active++;
  else inactive++;
}


// Bug 9 : Arrow function not returning value properly.


const getLifeCustomers = () => {
  return customers
    .filter(c => c.policy === "Life")
    .map(c => c.name);
};

// Bug 10 : sort() mutates original array.
const sortedCustomers = [...customers].sort((a, b) => b.premium - a.premium);