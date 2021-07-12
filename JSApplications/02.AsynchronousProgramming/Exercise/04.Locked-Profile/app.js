function lockedProfile() {
    getUserList();
}
//console.log('exo');   
async function getUserList() {
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    const main = document.querySelector('main');

    try  {
        const response = await fetch(url);

        if(response.ok == false) {
            throw new Error(response.statusText);
        }
        
        const users = await response.json();
        main.innerHTML = '';
       // console.log(users);
        Object.values(users).map(createProfile).forEach(u => main.appendChild(u));

       // console.log('Finish!')

    } catch (error) {
        alert(error.message);
    }
}

function createProfile({ age, email, username, _id }) {

    const divProfile = e('div');
    divProfile.className = 'profile';

    const img = e('img', undefined, 'userIcon', { src: './iconProfile2.png' });
    divProfile.appendChild(img);

    const labelLock = e('label', 'Lock', undefined, undefined);
    divProfile.appendChild(labelLock);
    const inputLock = e('input', undefined, undefined, { type: 'radio', name: 'user1Locked', value: 'lock', checked: true });
    divProfile.appendChild(inputLock);

    const labelUnlock = e('label', 'Unlock', undefined, undefined);
    divProfile.appendChild(labelUnlock);
    const inputUnlock = e('input', undefined, undefined, { type: 'radio', name: 'user1Locked', value: 'unlock' });
    divProfile.appendChild(inputUnlock);

    const br = e('br');
    divProfile.appendChild(br);

    const hr = e('hr');
    divProfile.appendChild(hr);

    const labelUser = e('label', 'Username', undefined, undefined);
    divProfile.appendChild(labelUser);

    const inputUser = e('input', undefined, undefined, { type: 'text', name: 'user1Username', value: username, disabled: true, readonly: true });
    divProfile.appendChild(inputUser);

    const divId = e('div', undefined, undefined, { id: _id }, divProfile);
    divProfile.appendChild(divId);

    const hr2 = e('hr');
    divId.appendChild(hr2);

    const labelEmail = e('label', 'Email:', undefined, undefined);
    divId.appendChild(labelEmail);

    const inputEmail = e('input', undefined, undefined, { type: 'email', name: 'user1Email', value: email, disabled: false, readonly: true });
    divId.appendChild(inputEmail);

    const labelAge = e('label', 'Age:', undefined, undefined);
    divId.appendChild(labelAge);

    const inputAge = e('input', undefined, undefined, { type: 'email', name: 'user1Age', value: age, disabled: true, readonly: true });
    divId.appendChild(inputAge);

    const showBtn = e('button', 'Show more', undefined, undefined);
    divProfile.appendChild(showBtn);

    divId.style.display = 'none';
    showBtn.addEventListener('click', () => {
        if (inputUnlock.checked) {
            divId.style.display = showBtn.textContent === 'Hide it' ? 'none' : 'block';
            showBtn.textContent = showBtn.textContent === 'Show more' ? 'Hide it' : 'Show more';
        }
    });

    return divProfile;
}

function e(type, text, className, attributes) {
    const element = document.createElement(type);
    if (text) {
        element.textContent = text;
    }
    if (className) {
        element.className = className;
    }
    if (attributes) {
        Object.entries(attributes).forEach(([key, value]) => {
            element.setAttribute(key, value == true ? '' : value);
        });
    }

    return element;
}