// higher order function
//Takes another function as an argument.
// or Returns another function as its result

function processData(input, callback) {
    return callback(input);
}

function toUpperCase(str) {
    return str.toUpperCase();
}
 
console.log(processData("abhi shek", toUpperCase));  

// callback with an array
// apply callback to every element

function forEachElement(arr,callback){
    for(let i=0;i<arr.length;i++){
        callback(arr[i],i);
    }
}

forEachElement([7,8,6],(element,index)=>{
    console.log(`element ${index}:${element*2}`);
})


// async callback
// https://fakestoreapi.com/products

// callback chaining



// 1. fetchData() is called
// 2. fetch() starts request (non-blocking)
// 3. fetchData() finishes execution
// 4. Network request completes (later)
// 5. .then() runs
// 6. callback(data) runs ← ASYNC CALLBACK HERE

function fetchData(url, callback) {
    fetch(url)
        .then(response => response.json()) 
        .then(data => {
            callback(data); 
        })
        .catch(error => {
            console.error("Error fetching data:", error);
        });
}

fetchData("https://fakestoreapi.com/products", (response) => {
    console.log("JSON Response:", response);
});
