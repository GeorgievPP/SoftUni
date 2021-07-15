let loadButton = document.querySelector('main aside .load');
loadButton.addEventListener('click', getCatches);

let allCatches = document.getElementById('catches');
allCatches.querySelectorAll('.catch').forEach(x => x.remove());

let addButton = document.querySelector('#addForm .add');
addButton.disabled = localStorage.getItem('token') === null;
addButton.addEventListener('click', createCatch);

async function getCatches() {
    let url = 'http://localhost:3030/data/catches';
    let response = await fetch(url);
    let data = await response.json();

    allCatches.querySelectorAll('.catch').forEach(x => x.remove());
    allCatches.append(...data.map(c => createHtmlCatch(c)));

}

async function updateCatch(){
    let currCatch = e.target.parentElement;
    let anglerInput = currCatch.querySelector('.angler');
    let weightInput = currCatch.querySelector('.weight');
    let speciesInput = currCatch.querySelector('.species');
    let locationInput = currCatch.querySelector('.location');
    let baitInput = currCatch.querySelector('.bait');
    let captureTimeInput = currCatch.querySelector('.captureTime');

    let body = JSON.stringify({
        angler: anglerInput.value,
        weight: Number(weightInput.value),
        species: speciesInput.value,
        location: locationInput.value,
        bait: baitInput.value,
        captureTime: Number(captureTimeInput.value)
    });

    let id = currCatch.dataset.id;
    let url = `http://localhost:3030/data/catches/${id}`;
    let response = await fetch(url, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        body
    });

    let result = await response.json();

}

async function deleteCatch(e) {
    let currCatch = e.target.parentElement;
    let id = currCatch.dataset.id;
    let url = `http://localhost:3030/data/catches/${id}`;
    let response = await fetch(url, {
        method: 'delete',
        headers: {
            'X-Authorization': localStorage.getItem('token')
        }
    });

   //let result = await response.json();

    if (response.status == 200) {
       
        let result = await response.json();
        console.log(result);
        currCatch.remove();
    }
}



async function createCatch(){
    let anglerInput = document.querySelector('#addForm .angler');
    let weightInput = document.querySelector('#addForm .weight');
    let speciesInput = document.querySelector('#addForm .species');
    let locationInput = document.querySelector('#addForm .location');
    let baitInput = document.querySelector('#addForm .bait');
    let captureTimeInput = document.querySelector('#addForm .captureTime');

    let newCatch = {
        angler: anglerInput.value,
        weight: Number(weightInput.value),
        species: speciesInput.value,
        location: locationInput.value,
        bait: baitInput.value,
        captureTime: Number(captureTimeInput.value)
    };

    let createResponse = await fetch('http://localhost:3030/data/catches',
    {
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        method: 'Post',
        body: JSON.stringify(newCatch)
    });
    let createResult = await createResponse.json();
    let createdCatch = createHtmlCatch(createResult);
    catchesContainer.appendChild(createdCatch);
}


function createHtmlCatch(currentCatch) {
    let anglerLabel = e('label', undefined, 'Angler');
    let anglerInput = e('input', {type: 'text', class: 'angler'}, currentCatch.angler);
    let hr1 = e('hr');
    let weightLabel = e('label', undefined, 'Weight');
    let weightInput = e('input', {type: 'number', class: 'weight'}, currentCatch.weight);
    let hr2 = e('hr');
    let speciesLabel = e('label', undefined, 'Species');
    let speciesInput = e('input', {type: 'text', class: 'species'}, currentCatch.species);
    let hr3 = e('hr');
    let locationLabel = e('label', undefined, 'Location');
    let locationInput = e('input', {type: 'text', class: 'location'}, currentCatch.location);
    let hr4 = e('hr');
    let baitLabel = e('label', undefined, 'Bait');
    let baitInput = e('input', {type: 'text', class: 'bait'}, currentCatch.bait);
    let hr5 = e('hr');
    let captureTimeLabel = e('label', undefined, 'Capture Time');
    let captureTimeInput = e('input', {type: 'number', class: 'captureTime'}, currentCatch.captureTime);
    let hr6 = e('hr');
    
    let updateBtn = e('button', {disabled:true, class:'update' }, 'Update');
    updateBtn.addEventListener('click', updateCatch);
    updateBtn.disabled = localStorage.getItem('userId') != currentCatch._ownerId;

    let deleteBtn = e('button', {disabled:true, class: 'delete' }, 'Delete');
    deleteBtn.addEventListener('click', deleteCatch);
    deleteBtn.disabled = localStorage.getItem('userId') != currentCatch._ownerId;

    let catchDiv = e('div', {class: 'catch' },
    anglerLabel, anglerInput, hr1, weightLabel, weightInput, hr2, speciesLabel, speciesInput,
    hr3, locationLabel, locationInput, hr4, baitLabel, baitInput, hr5, captureTimeLabel,
    captureTimeInput, hr6,updateBtn, deleteBtn);
    catchDiv.dataset.id = currentCatch._id;
    catchDiv.dataset.ownerId = currentCatch._ownerId;

    return catchDiv;

}

function e(tag, attributes, ...params) {
    let element = document.createElement(tag);

    let firstValue = params[0];
    if (params.length === 1 && typeof (firstValue) !== 'object') {
        if (['input', 'textarea'].includes(tag)) {
            element.value = firstValue;
        } else {
            element.textContent = firstValue;
        }
    } else {
        element.append(...params);
    }

    if (attributes !== undefined) {
        Object.keys(attributes).forEach(key => {
            element.setAttribute(key, attributes[key]);
        })
    }

    return element;
}

