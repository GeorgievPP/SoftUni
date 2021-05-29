function extractText() {
    let listElements = document.querySelectorAll('#items li');
    for(let li of listElements){
        document.getElementById('result').value += li.textContent + "\n";
    }
}
