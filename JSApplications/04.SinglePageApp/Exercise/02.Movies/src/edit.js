import { showDetails } from './details.js';

async function getMovieById(id) {
    const response = await fetch('http://localhost:3030/data/movies/' + id);
    const data = await response.json();

    return data;
}

async function onSubmit(data) {
    const body = JSON.stringify({
        title: data.title,
        description: data.description,
        img: data.imageUrl
    });

    const token = sessionStorage.getItem('authToken');
    if (token == null) {
        return alert('You\'re not logged in');
    }

    try {
        const response = await fetch('http://localhost:3030/data/movies/' + help, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            },
            body
        });
        
        if (response.status == 200) {
          showDetails(help);
        } else {
            throw new Error(await response.json());
        }
    } catch (err) {
        console.error(err.message);
    }
}

let help;

let main;
let section;

export function setupEdit(mainTarget, sectionTarget){
    main = mainTarget;
    section = sectionTarget;
    
    const form = section.querySelector('form');

    form.addEventListener('submit', (ev => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        onSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
    }));
}

export async function showEdit(id) {
    main.innerHTML = '';
    main.appendChild(section);

    help = id;

    const movie = await getMovieById(id);

    section.querySelector('[name="title"]').value = movie.title;
    section.querySelector('[name="description"]').value = movie.description;
    section.querySelector('[name="imageUrl"]').value = movie.img;
}