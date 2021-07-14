function solution() {
    loadStudents();
    
    const form = document.getElementById('form');

    form.addEventListener('submit', (ev) => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        onSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
        form.reset();
    });
    
}

solution();

async function onSubmit(data) {
    const body = JSON.stringify({
        firstName: data.firstName,
        lastName: data.lastName,
        facultyNumber: data.facultyNumber,
        grade: data.grade
    });

    const response = await fetch('http://localhost:3030/jsonstore/collections/students', {
        method: 'post',
        headers: {'Content-Type': 'application/json' },
        body
    });

    if (response.status == 200) {
       loadStudents();
    } 
}

async function loadStudents() {
    const tBody = document.getElementById('tableto');
    tBody.innerHTML = '';
    const response = await fetch('http://localhost:3030/jsonstore/collections/students');
    const data = await response.json();

    Object.values(data).map(createStudent).forEach((s) => tBody.append(s));
}

function createStudent(student) {
    const data = document.createElement('tr');
    const firstName = e('th', student.firstName);
    const lastName = e('th', student.lastName);
    const facultyNumber = e('th', student.facultyNumber);
    const grade = e('th', student.grade);

    data.append(firstName, lastName, facultyNumber, grade);
    return data;

}

function e(type, text) {
    const element = document.createElement(type);
    element.textContent = text;
    return element;
}