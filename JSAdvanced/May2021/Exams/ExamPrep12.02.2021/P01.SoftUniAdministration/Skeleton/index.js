function solve() {
    //save all modules
    const state = {};
    //select training section
    const trainingModule = document.querySelector('.modules');
    //select all inputs
    const [nameInput, dateInput, moduleInput, addBtn] = Array.from(
        document.querySelector('form').children)
        .map((input) => input.children[1] ? input.children[1] : input.children[0]);

    //add eventListener on addBtn
    addBtn.addEventListener('click', (ev) => {
        ev.preventDefault();
        let [name, date, moduleName] = [nameInput, dateInput, moduleInput].map(
            (el) => el.value
        );
        //validate inputs
        if (name == "" || date == "" || moduleName == 'Select moduleName') {
            return;
        }

        //create moduleName 
        date = convertDate(date);
        const h4 = createElement('h4', `${name} - ${date}`)
        const butnDel = createElement('button', 'Del', 'red');
        butnDel.addEventListener('click', onDel);
        const li = createElement('li', undefined, 'flex');

        [h4, butnDel].forEach((el) => li.appendChild(el));

        let module = undefined
        let ul = undefined
        let lis = undefined;

        // check if currentModule is alredy added
        if (!state[moduleName]) {
            let h3 = createElement('h3', `${moduleName.toUpperCase()}-MODULE`);
            ul = createElement('ul');
            lis = [];
            module = createElement('div', undefined, 'module');

            [h3, ul].forEach((el) => module.appendChild(el));

            state[moduleName] = { module, ul, lis: [] }; //create structure
        } else {
            module = state[moduleName].module
            ul = state[moduleName].ul;
        }

        state[moduleName].lis.push({ li, date });

        state[moduleName].lis.sort((a, b) => a.date.localeCompare(b.date))
            .forEach(({ li }) => { ul.appendChild(li) });
        [nameInput, dateInput, moduleInput, addBtn].forEach((el) => el.value = '');
        trainingModule.appendChild(module);
    });

    function onDel(e) {
        const li = e.target.parentNode;
        const ul = li.parentNode;
        const module = ul.parentNode
        li.remove();

        if (!ul.children.length) {
            module.remove();
        }
    }
    function convertDate(dateValue) {
        while (dateValue.includes("-")) {
            dateValue = dateValue.replace("-", "/");
        }
        dateValue = dateValue.replace("T", " - ");
        return dateValue;
    }

    function createElement(type, content, attribute) {
        const el = document.createElement(type);
        if (attribute) {
            el.setAttribute('class', attribute);
        } if (content) {
            el.textContent = content;
        }
        return el;
    }
};





/*
function solve() {
    const formControls = document.querySelectorAll('.form-control input');
    const lecture = formControls[0];
    const date = formControls[1];
    const moduleName = document.querySelector('select');
    const modulesOutput = document.querySelector('.modules');

    let state = {};

    function createElement(type, text, attributes = []) {
        let element = document.createElement(type);
        if(text){
            element.textContent = text;
        }

        attributes
            .map(attr => attr.split('='))
            .forEach(([name, value]) => {
                element.setAttribute(name, value);
            });

        return element;
    }

    function add(e){
        e.preventDefault();

        if(lecture.value === '' || date.value === '' || moduleName === 'Select module') {
            return;
        }

        let lectureName = lecture.value;
        let dateString = date.value;

        const lectureTitle = lectureName + ' - ' + dateString.split('-').join('/').split('T').join(' - ');

        const delBtn = createElement('button', 'Del', ['class=red']);
        const lectureH4 = createElement('h4', lectureTitle);
        const li = createElement('li', undefined, ['class=flex']);

        li.appendChild(lectureH4);
        li.appendChild(delBtn);

        let module;
        let ul;

        if(!state[moduleName.value]) {
            let h3 = createElement('h3', `${moduleName.value.toUpperCase()}-MODULE`);
            ul = createElement('ul');
            lis = [];
            module = createElement('div', undefined, ['class=module']);

            module.appendChild(h3);
            module.appendChild(ul);

            state[moduleName.value] = { module, ul, lis: []};
        } else {
            module = state[moduleName.value].module;
            ul = state[moduleName.value].ul;
        }

        state[moduleName.value].lis.push({li, date: date.value});

        state[moduleName.value].lis.sort((a, b) => {
            return a.date.localCompare(b.date);
        }).forEach(({li}) => {
            ul.appendChild(li);
        });

    }

    function del(e) {
        let li = e.target.parentNode;
        let ul = li.parentNode;
        let module = ul.parentNode;

        li.remove();

        if(ul.children.length===0) {
            module.remove();
        }
    }

    document.getElementsByTagName('main')[0].addEventListener('click', (e) => {
        if(e.target.tagName === 'BUTTON') {
            if(!e.target.classList.contains('red')) {
                add(e);

                Object.entries(state).forEach(([name, module]) => {
                    modulesOutput.appendChild(module.module)
                })
            } else {
                del(e);
            }
        }
    })
};*/