let policies = [];

const policiesData = [
  { id: 1, name: "Health Plus", type: "Health", premium: 12000, duration: 1, status: "Active" },
  { id: 2, name: "Life Secure", type: "Life", premium: 9000, duration: 10, status: "Inactive" },
  { id: 3, name: "Car Protect", type: "Vehicle", premium: 7000, duration: 1, status: "Active" },
  { id: 4, name: "Family Health", type: "Health", premium: 15000, duration: 2, status: "Active" }
];


//task-1
async function fetchPolicies() {
  try {
    await new Promise(resolve => setTimeout(resolve, 1000)); 
    policies = [...policiesData];
    applyDiscount();
    displayPolicies(policies);
    calculateTotalPremium();
  } catch (error) {
    showMessage("API Fetch Failed", "text-red-600");
  }
}

//task-2
 
function displayPolicies(data) {
  const container = document.getElementById("policyList");
  container.innerHTML = "";

  data.forEach(policy => {
    container.innerHTML += `
      <div class="bg-white p-4 rounded shadow flex justify-between items-center">
        <div>
          <h3 class="font-bold text-lg">${policy.name}</h3>
          <p>Type: ${policy.type}</p>
          <p>Premium: ₹${policy.premium}</p>
          <p>Duration: ${policy.duration} year(s)</p>
          <p>Status: ${policy.status}</p>
        </div>
        <button
          onclick="purchasePolicy(${policy.id})"
          class="bg-black text-white px-3 py-1 rounded">
          Buy
        </button>
      </div>
    `;
  });
}

//task-3
 
function filterPolicies(type) {
  if (type === "All") {
    displayPolicies(policies);
  } else {
    const filtered = policies.filter(p => p.type === type);
    displayPolicies(filtered);
  }
}

 //task-4
function calculateTotalPremium() {
  try {
    const total = policies
      .filter(p => p.status === "Active")
      .reduce((sum, p) => sum + p.premium, 0);

    document.getElementById("totalPremium").textContent = total;
  } catch {
    showMessage("Premium Calculation Error", "text-red-600");
  }
}


//task-5
  
function applyDiscount() {
  policies = policies.map(policy =>
    policy.premium > 10000
      ? { ...policy, premium: Math.round(policy.premium * 0.9) }
      : policy
  );
}

//task-6
function approvePolicyCallback(policyId, callback) {
  setTimeout(() => {
    const policy = policies.find(p => p.id === policyId);
    if (!policy) {
      callback("Invalid Policy ID", null);
    } else {
      callback(null, "Policy Approved");
    }
  }, 2000);
}


//task-7
function approvePolicyPromise(policyId) {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const policy = policies.find(p => p.id === policyId);
      policy ? resolve("Policy Purchased Successfully") : reject("Policy Not Found");
    }, 2000);
  });
}


async function purchasePolicy(id) {
  showMessage("Processing purchase...", "text-blue-600");
  try {
    const result = await approvePolicyPromise(id);
    showMessage(result, "text-green-600");
  } catch (error) {
    showMessage(error, "text-red-600");
  }
}

 
function showMessage(msg, className) {
  const message = document.getElementById("message");
  message.textContent = msg;
  message.className = className;
}
 
fetchPolicies();






