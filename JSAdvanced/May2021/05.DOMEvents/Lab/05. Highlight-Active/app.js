function focused() {
    Array.from(document.querySelectorAll('input')).forEach(i => {
        i.addEventListener('focus', onFocus);
        i.addEventListener('blur', onBlur);
    });

    function onFocus(ev) {
        //onFocus -> select input parent -> apply class "focused"
        ev.target.parentNode.className = 'focused';
    }

    function onBlur(ev) {
        //onBlur -> select input parent -> remove class "focused"
        ev.target.parentNode.className = '';
    }
}