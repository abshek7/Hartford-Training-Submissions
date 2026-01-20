const API_URL = "https://jsonplaceholder.typicode.com/users";
      const tableBody = document.getElementById("accountsTableBody");
      const loader = document.getElementById("loader");
      const searchInput = document.getElementById("searchInput");
      const branchFilter = document.getElementById("branchFilter");
      const totalBalanceEl = document.getElementById("totalBalance");

      let accounts = [];

       
      const randomBalance = () =>
        Math.floor(Math.random() * (50000 - 10000 + 1)) + 10000;

      const saveData = () =>
        localStorage.setItem("accounts", JSON.stringify(accounts));

      const loadData = () => JSON.parse(localStorage.getItem("accounts"));

      /* ------------------ Fetch Accounts ------------------ */
      async function fetchAccounts() {
        loader.classList.remove("hidden");
        try {
          const res = await fetch(API_URL);
          const data = await res.json();

          accounts = data.map((u) => ({
            accountNumber: u.id,
            name: u.name,
            email: u.email,
            branch: u.address.city,
            balance: randomBalance(),
            transactions: [],
          }));

          saveData();
          populateBranches();
          displayAccounts(accounts);
        } catch {
          alert("Failed to fetch data");
        } finally {
          loader.classList.add("hidden");
        }
      }

      /* ------------------ Display ------------------ */
      function displayAccounts(list) {
        tableBody.innerHTML = "";

        list.forEach((acc) => {
          const row = document.createElement("tr");
          row.className = "border-b";

          row.innerHTML = `
      <td class="p-2">${acc.accountNumber}</td>
      <td class="p-2">${acc.name}</td>
      <td class="p-2">${acc.email}</td>
      <td class="p-2">${acc.branch}</td>
      <td class="p-2">₹${acc.balance}</td>
      <td class="p-2 flex gap-2 flex-wrap">
        <button class="bg-black text-white px-2 rounded"
          onclick="transaction(${acc.accountNumber}, 'Deposit')">Deposit</button>

        <button class="bg-black text-white px-2 rounded"
          onclick="transaction(${acc.accountNumber}, 'Withdraw')">Withdraw</button>

        <button class="bg-black text-white px-2 rounded"
          onclick="viewHistory(${acc.accountNumber})">History</button>

        <button class="bg-black text-white px-2 rounded"
          onclick="deleteAccount(${acc.accountNumber})">Delete</button>
      </td>
    `;
          tableBody.appendChild(row);
        });

        updateTotalBalance();
      }

      /* ------------------ Search & Filter ------------------ */
      function populateBranches() {
        branchFilter.innerHTML = '<option value="">All Branches</option>';
        [...new Set(accounts.map((a) => a.branch))].forEach((b) => {
          branchFilter.innerHTML += `<option>${b}</option>`;
        });
      }

      function applyFilters() {
        const text = searchInput.value.toLowerCase();
        const branch = branchFilter.value;

        const filtered = accounts.filter(
          (a) =>
            a.name.toLowerCase().includes(text) &&
            (branch === "" || a.branch === branch)
        );

        displayAccounts(filtered);
      }

      searchInput.addEventListener("input", applyFilters);
      branchFilter.addEventListener("change", applyFilters);

      /* ------------------ Transactions ------------------ */
      function transaction(id, type) {
        const acc = accounts.find((a) => a.accountNumber === id);
        const amt = Number(prompt(`Enter ${type} amount:`));
        if (!amt || amt <= 0) return;

        if (type === "Withdraw" && acc.balance < amt) {
          alert("Insufficient Balance");
          return;
        }

        acc.balance += type === "Deposit" ? amt : -amt;

        if (acc.balance < 5000) {
          acc.balance -= 200;
          alert("Minimum balance breached. ₹200 penalty applied.");
        }

        acc.transactions.push({
          type,
          amount: amt,
          date: new Date().toLocaleString(),
        });

        saveData();
        applyFilters();
      }

      /* ------------------ History ------------------ */
      function viewHistory(id) {
        const acc = accounts.find((a) => a.accountNumber === id);
        if (acc.transactions.length === 0) {
          alert("No transactions");
          return;
        }
        alert(
          acc.transactions
            .map((t) => `${t.date} | ${t.type} ₹${t.amount}`)
            .join("\n")
        );
      }

      /* ------------------ Create Account ------------------ */
      document.getElementById("accountForm").addEventListener("submit", (e) => {
        e.preventDefault();

        const acc = {
          accountNumber: Date.now(),
          name: name.value,
          email: email.value,
          branch: branch.value,
          balance: 10000,
          transactions: [],
        };

        fetch(API_URL, {
          method: "POST",
          body: JSON.stringify(acc),
          headers: { "Content-Type": "application/json" },
        });

        accounts.push(acc);
        saveData();
        populateBranches();
        applyFilters();
        e.target.reset();
      });

      /* ------------------ Delete ------------------ */
      function deleteAccount(id) {
        if (!confirm("Delete account?")) return;

        fetch(`${API_URL}/${id}`, { method: "DELETE" });
        accounts = accounts.filter((a) => a.accountNumber !== id);
        saveData();
        applyFilters();
      }

      /* ------------------ Sort & Total ------------------ */
      function sortByBalance() {
        accounts.sort((a, b) => b.balance - a.balance);
        applyFilters();
      }

      function updateTotalBalance() {
        const total = accounts.reduce((sum, a) => sum + a.balance, 0);
        totalBalanceEl.textContent = total;
      }

      /* ------------------ Init ------------------ */
      const stored = loadData();
      if (stored) {
        accounts = stored;
        populateBranches();
        displayAccounts(accounts);
      } else {
        fetchAccounts();
      }