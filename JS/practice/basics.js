// const num=42;
// const ans=num+"1";
// console.log(ans)

// implicit conversion
console.log(null==undefined)
console.log("7"==false)
console.log(true==true)
console.log("0"==false)

console.log("---------------")

console.log(null===undefined)
console.log("7"===false)
console.log(true===true)
console.log("0"===false)



//varibles
let companyName="The Hartford";
let noOfActivePolicies="225";
let isHealthInsuranceOffered=true;

console.log("The company name is:",companyName)
console.log("The active no of policies:",noOfActivePolicies)
console.log("Is Health insurance offered:",isHealthInsuranceOffered)

//basic ops

const base=6000;
const taxPercent=18;
let total=base+(taxPercent/100)*base;

console.log("Total premium is:",total);


// const ip1=document.getElementById('in1').value;
// const ip2=document.getElementById('in2').value;
// const sum=parseFloat(ip1)+parseFloat(ip2);
// document.getElementById('result').textContent=sum;


// //
// const customerAge=prompt("Please enter your age")
// if(customerAge>=18){
//     console.log("Customer is eligible")
// }else{
//     console.log("Customer is not eligible")
// }



function checkEligibility(age) {
    return age >= 18;
}

//predefined input
const customerAge = 25;

if (checkEligibility(customerAge)) {
    console.log("Customer is eligible");
} else {
    console.log("Customer is not eligible");
}

console.log(checkEligibility(18));
console.log(checkEligibility(17));  
console.log(checkEligibility(30));  
console.log(checkEligibility(16));  
