function toggle() {
    let button = document.querySelector('.button');
    let divExtra = document.querySelector('#extra');

    divExtra.style.display = (divExtra.style.display == 'none' ||
                                divExtra.style.display == ' ')
                                ? 'block' : 'none';
    button.textContent = button.textContent == 'More' ? 'Less' : 'More';
}








/*function toggle() {
    let btn = document.getElementsByClassName('button')[0];
    let info = document.getElementById('extra');
    if(btn.textContent == 'More') {
        info.style.display = 'block';
        btn.textContent = 'Less';
    } else {
        btn.textContent = 'More';
        info.style.display = '';
    }
}*/


