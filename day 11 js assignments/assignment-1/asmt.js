"use strict";
//task-1 change dashboard title
document.getElementById('pageTitle').textContent='Customer Insurance Overview';

//task-2
const liElements=document.getElementsByTagName("li");
for(let li of liElements){
    li.style.border='3px solid red';
}

console.log(liElements.length);


//task-3

const policyElements=document.getElementsByClassName("policy");
for(let policy of policyElements){
    policy.classList.add('highlight');

    policy.style.color='blue';
}

//task-4
//select first
const firstCustomer=document.querySelector('.customer');
console.log('first customer:',firstCustomer.textContent);
// console.log(firstCustomer.classList)

//select all
const allCustomer=document.querySelectorAll('.customer');
for(let cust of allCustomer){
console.log('customer:',cust.textContent);
}

//select last and mark as active

const finalCustomer=document.querySelector('.customer:last-child');
finalCustomer.classList.add('active');
console.log(finalCustomer.classList)

//task-5 HTML Object Collections
console.log('number of forms',document.forms.length)
console.log('number of images',document.images.length)




// Task 6 – Add a new customer dynamically

const customerList = document.getElementById('customerList');
const newCustomer = document.createElement('li');
newCustomer.className = 'customer';
newCustomer.textContent = 'Priya Travel';
customerList.appendChild(newCustomer);

console.log('After adding new customer:');
console.log('getElementsByTagName updates automatically:', document.getElementsByTagName('li').length);
console.log('getElementsByClassName updates automatically:', document.getElementsByClassName('customer').length);
console.log('querySelectorAll does NOT update automatically:', document.querySelectorAll('.customer').length);

// Task 7 – Attribute-Based Selection
// Select only input fields whose type is "text"
const textInputs = document.querySelectorAll('input[type="text"]');
textInputs.forEach(input => {
  input.style.backgroundColor = 'yellow';
  input.placeholder = 'Enter Full Name';
});

// Task 8 – Multiple Class Selection
// Select all elements that have both customer and active classes
const activeCustomers = document.querySelectorAll('.customer.active');
activeCustomers.forEach(customer => {
  customer.style.color = 'darkgreen';
  customer.textContent += ' (Priority Customer)';
});

// Task 9 – Descendant vs Child Selector
// Select all <li> elements inside #customerList using descendant selector
const descendantLi = document.querySelectorAll('#customerList li');
console.log('Descendant selector <li> count:', descendantLi.length);

// Select only direct child <li> using child selector
const childLi = document.querySelectorAll('#customerList > li');
console.log('Child selector <li> count:', childLi.length);
console.log('Difference: Descendant selects all nested <li>, child selects only direct children');

// Task 10 – Even / Odd Selection (CSS Pseudo Selectors)
// Highlight even customers in light gray
const evenCustomers = document.querySelectorAll('#customerList .customer:nth-child(even)');
evenCustomers.forEach(customer => {
  customer.style.backgroundColor = 'lightgray';
});

// Highlight odd customers in light blue
const oddCustomers = document.querySelectorAll('#customerList .customer:nth-child(odd)');
oddCustomers.forEach(customer => {
  customer.style.backgroundColor = 'lightblue';
});

// Task 11 – Form Elements Collection
// Access the enquiry form
const enquiryForm = document.forms['enquiryForm'];
console.log('Form accessed:', enquiryForm);

// Log all input field names
const formElements = enquiryForm.elements;
console.log('Input field names:');
for (let element of formElements) {
  if (element.name) {
    console.log(element.name);
  }
}

// Disable the submit button
const submitButton = enquiryForm.querySelector('button[type="submit"]');
submitButton.disabled = true;

// Task 12 – NodeList vs HTMLCollection
// Select policies using getElementsByClassName
const policiesHTMLCollection = document.getElementsByClassName('policy');
console.log('HTMLCollection count before adding:', policiesHTMLCollection.length);

// Select policies using querySelectorAll
const policiesNodeList = document.querySelectorAll('.policy');
console.log('NodeList count before adding:', policiesNodeList.length);

// Dynamically add a new policy
const newPolicy = document.createElement('p');
newPolicy.className = 'policy';
newPolicy.textContent = 'Travel Insurance';
document.querySelector('form').insertAdjacentElement('beforebegin', newPolicy);

console.log('HTMLCollection count after adding (updates automatically):', policiesHTMLCollection.length);
console.log('NodeList count after adding (does NOT update):', policiesNodeList.length);

// Task 13
//  Highlight customers whose policy includes "Life"
const customers = document.querySelectorAll('.customer');
customers.forEach(customer => {
  if (customer.textContent.includes('Life')) {
    customer.style.backgroundColor = 'lightyellow';
  }
  // Hide customers whose policy includes "Vehicle"
  if (customer.textContent.includes('Vehicle')) {
    customer.style.display = 'none';
  }
});

// Task 14
// When clicking any customer <li>, find the nearest <ul> and add a border
document.querySelectorAll('.customer').forEach(customer => {
  customer.addEventListener('click', function() {
    const nearestUl = this.closest('ul');
    nearestUl.style.border = '3px solid red';
  });
});

// Task 15 – Complex Selector Challenge 
const policiesExceptFirst = document.querySelectorAll('.policy:not(:first-child)');
policiesExceptFirst.forEach(policy => {
  policy.style.fontStyle = 'italic';
  policy.textContent = '✔ ' + policy.textContent;
});
 
