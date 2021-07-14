function attachEvents() {
    document.getElementById('refresh').addEventListener('click', getMessages);
    document.getElementById('submit').addEventListener('click', sendMessage);

}

attachEvents();

async function getMessages() {
    const response = await fetch('http://localhost:3030/jsonstore/messenger');
    const data = await response.json();

    const messages = Object.values(data).map(v => `${v.author}: ${v.content}`).join('\n');
    document.getElementById('messages').value = messages;
}

async function sendMessage() {
    const author = document.getElementById('author').value;
    const content = document.getElementById('content').value;
/*
    if (author == '' || content == '') {
        return alert('All fields are required!');
    }
    */

    await fetch('http://localhost:3030/jsonstore/messenger', {
        method: 'post',
        headers: { 'Content-Type': 'applications/json' },
        body: JSON.stringify({ author, content })
    });

    document.getElementById('author').value = '';
    document.getElementById('content').value = '';

    getMessages();
}