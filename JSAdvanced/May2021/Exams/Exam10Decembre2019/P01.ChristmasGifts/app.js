function solution() {
    let input = document.querySelector('input');
    let addButton = document.querySelector('button');
    let gifts = document.querySelector('.container > section:nth-of-type(2) ul');
    let sentGifts = document.querySelector('.container > section:nth-of-type(3) ul');
    let discardedGifts = document.querySelector('.container > section:nth-of-type(4) ul');

    addButton.addEventListener('click', addGift);

    function addGift() {
        if (input.value.trim()) {
            let sendButton = document.createElement('button');
            sendButton.setAttribute('id', 'sendButton');
            sendButton.textContent = 'Send';

            let discardButton = document.createElement('button');
            discardButton.setAttribute('id', 'discardButton');
            discardButton.textContent = 'Discard';

            let item = document.createElement('li');
            item.setAttribute('class', 'gift');
            item.textContent = input.value;
            item.appendChild(sendButton);
            item.appendChild(discardButton);

            gifts.appendChild(item);

            //sort gifts alphabetically

            Array.from(gifts.querySelectorAll('li'))
                .sort((a, b) => a.textContent.localeCompare(b.textContent))
                .forEach(item => gifts.appendChild(item));

            input.value = null;

            [sendButton, discardButton].forEach(btn => btn.addEventListener('click', manageGifts));
        }
    }

    function manageGifts(btn) {
        let item = btn.target.parentNode;
        item.lastElementChild.remove();
        item.lastElementChild.remove();

        if(btn.target.textContent === 'Send') {
            sentGifts.appendChild(item);
        } else {
            discardedGifts.appendChild(item);
        }
    }
}