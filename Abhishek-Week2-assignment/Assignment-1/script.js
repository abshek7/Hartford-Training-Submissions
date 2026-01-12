"use strict";
const form=document.getElementById("enquiryForm");
const successMsg=document.getElementById("successMsg");

form.addEventListener("submit",function(e){
    e.preventDefault();
    let isValid=true;
    successMsg.textContent="";

    document.querySelectorAll(".error").forEach(Element=>Element.textContent="");

    //form fields
    const name=document.getElementById("name");
    const email=document.getElementById("email");
    const phone=document.getElementById("phone");
    const requestType=document.getElementById("requestType");
    const policyType=document.getElementById("policyType");
    const message = document.getElementById("message");
    const rating = document.querySelector('input[name="rating"]:checked');

    
    if(name.value.trim()===""){
        showError(name,"this is required field");
        isValid=false;
    }


    if(email.value.trim()===""){
        showError(email,"this email is required field");
        isValid=false;
    }

    if (phone.value.trim() === "") {
    showError(phone, "Phone number is required");
    isValid = false;
} else if (!/^\d{10}$/.test(phone.value)) {
    showError(phone, "Phone number must be 10 digits");
    isValid = false;
}
    if(requestType.value===""){
         showError(requestType,"please select any one of type");
         isValid=false;
    }

    if(policyType.value===""){
         showError(policyType,"please select any one of type");
         isValid=false;
    }

    if(message.value.trim().length<10){
        showError(message,"message should be atleast of 10 chars")
        isValid=false;
    }

    if (!rating) {
        document.querySelector('.radio-group').nextElementSibling.textContent = "Please select rating";
        isValid = false;
    }
    if(isValid){
        successMsg.textContent="thanks for submission";
        form.reset();
    }
});

function showError(input,message){
    const field=input.parentElement;
    field.querySelector(".error").textContent=message;
}