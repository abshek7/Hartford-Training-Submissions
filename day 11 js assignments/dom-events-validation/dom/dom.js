const p = document.getElementById("para");
console.log(p);


const items=document.getElementsByClassName("text");

console.log(items);


const paragraphs = document.getElementsByTagName("p");

console.log(paragraphs);



const title=document.getElementsByTagName("title");


document.querySelector("p");        // first <p>
document.querySelector(".text");    // first class
document.querySelector("#para");   



// for accessing 2nd class named text which displays two
const texts = document.querySelectorAll(".text");
const secondText = texts[1];

console.log(secondText.textContent);


const allParas=document.querySelectorAll("p");
allParas.forEach(p => {
  p.style.color = "red";
});


const body=document.body;
body.append("this is abhishek");


title.textContent="updated dom basics";

console.log(title);


 

items[1].innerHTML = "<strong>Bold Second Paragraph</strong>";




const div=document.createElement("div");
div.textContent="hello this is created element";
body.append(div);

console.log(div);


let newImg=document.createElement("img");

newImg.src="https://tinyurl.com/yrdue377";


newImg.alt="basic of dom";

document.body.appendChild(newImg)