const API = "https://jsonplaceholder.typicode.com/posts";

function fetchAllPosts() {
    fetch(API)
        .then(res => res.json())
        .then(data => {
            tablebody.innerHTML = "";
            data.forEach(post => {
                tablebody.innerHTML += `
                <tr id="row-${post.id}">
                    <td class="p-2 border">${post.id}</td>
                    <td class="p-2 border">${post.title}</td>
                    <td class="p-2 border space-x-2">
                        <button onclick="DeletePost(${post.id})" class="bg-black text-white px-2 py-1 rounded">DELETE</button>
                        <button onclick="GetPostById(${post.id})" class="bg-black text-white px-2 py-1 rounded">GET</button>
                    </td>
                </tr>`;
            });
        });
}

function DeletePost(id) {
    fetch(`${API}/${id}`, { method: "DELETE" })
        .then(res => {
            if (res.ok) {
                const row = document.getElementById(`row-${id}`);
                if (row) row.remove();
            }
        });
}

function GetPostById(id) {
    fetch(`${API}/${id}`)
        .then(res => res.json())
        .then(data => {
            updateId.value = data.id;
            updateUserId.value = data.userId;
            updateTitle.value = data.title;
            updateBody.value = data.body;
        });
}

formData.addEventListener("submit", e => {
    e.preventDefault();

    fetch(API, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            userId: addUserId.value,
            title: addTitle.value,
            body: addBody.value
        })
    })
    .then(res => res.json())
    .then(() => {
        alert("Post created");
        formData.reset();
    });
});

UpdateFormData.addEventListener("submit", e => {
    e.preventDefault();

    const id = updateId.value.trim();
    if (!id) return alert("Post ID required");

    const payload = {};
    if (updateUserId.value) payload.userId = updateUserId.value;
    if (updateTitle.value) payload.title = updateTitle.value;
    if (updateBody.value) payload.body = updateBody.value;

    const method = Object.keys(payload).length === 3 ? "PUT" : "PATCH";

    fetch(`${API}/${id}`, {
        method,
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(method === "PUT" ? { id, ...payload } : payload)
    })
    .then(res => res.json())
    .then(() => {
        alert(method + " success");
        UpdateFormData.reset();
    });
});
