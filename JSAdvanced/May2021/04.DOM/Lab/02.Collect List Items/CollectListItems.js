function extractText() {
    /*let listElements = document.querySelectorAll('#items li');
    for(let li of listElements){
        document.getElementById('result').value += li.textContent + "\n";
    }*/

    const liElements = [...document.getElementsByTagName('li')];
    const elementText = liElements.map(e => e.textContent);

    document.getElementById('result').value = elementText.join('\n');
}
