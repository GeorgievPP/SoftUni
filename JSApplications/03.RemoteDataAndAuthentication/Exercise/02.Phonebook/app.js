function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', loadPost);
    document.getElementById('btnCreate').addEventListener('click', createContact);
}

attachEvents();

async function loadPost() {
    const ul = document.getElementById('phonebook');
    const response = await fetch('http://localhost:3030/jsonstore/phonebook');
    const data = await response.json();

    ul.innerHTML = '';

    console.log(data);

    Object.values(data) .map(createLiElement) .forEach((p) => ul.appendChild(p))
}

async function deletePost(event) {
    const id = event.target.parentNode.id;

    const response = await fetch(`http://localhost:3030/jsonstore/phonebook/` + id, {
        method:'delete',
        headers:{'Content-Type': 'applications/json' },
    });

    event.target.parentNode.remove();
}

async function createContact() {
    const person = document.getElementById('person').value;
    const phone = document.getElementById('phone').value;

    if(person && phone) {
        const response = await fetch('http://localhost:3030/jsonstore/phonebook', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ person, phone })
        });
    } else {
        return alert('Empty input field/s !');
    }

    loadPost();
}

function createLiElement({ person, phone, _id }) {
    const liElement = document.createElement('li');
    liElement.setAttribute('id', _id);
    liElement.textContent = `${person}: ${phone}`;

    const delBtn = document.createElement('button');
    delBtn.textContent = 'Delete';
    delBtn.addEventListener('click', deletePost);
    
    liElement.append(delBtn);

    return liElement;
}