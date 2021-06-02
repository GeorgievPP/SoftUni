/*function addItem() {
   //select input field and read input value
   const text = document.getElementById('newItemText').value;

   //create new <li> element
   const liElement = document.createElement('li');

   //set text of element to input value
   liElement.textContent = text;

   //select list from page
   const ulElement = document.getElementById('items');

   //append new element to list
   ulElement.appendChild(liElement);
}*/

function addItem() {
    //create new <li> element 
    const liElement = document.createElement('li');

//set text of new element to input value
liElement.textContent = document.getElementById('newItemText').value;

//select list from page and append new element to list
document.getElementById('items').appendChild(liElement);

document.getElementById('newItemText').value = '';
}